// ManejadorDados.cs created with MonoDevelop
// User: tas at 12:35 06/08/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.Generic;
using Dinero = System.Decimal;

namespace CasinoNEW
{
	public class ManejadorDados
	{

		private static EscritorDados escritor = new EscritorDados();

		public static void Notificar(int id, string usuario, int idMesa, 
		                      IList<Jugador> jugadores, Jugador proxTirador,
		                      bool proxTiroSalida, int punto, 
		                      Jugador ultimoTirador, Resultado ultimoResultado,
							  Dictionary<Jugador, IList<Premio>> premios, 
		                     Dictionary<Jugador,IList<ApuestaDados>> apuestas){
			
			escritor.NotificarEstado(id, usuario, idMesa, jugadores,
									 proxTirador, proxTiroSalida, punto, ultimoTirador,
									 ultimoResultado, premios, apuestas);

		
		}
		
	
		public void EntrarCrapsMesa(int id, string usuario, int idMesa){
			Jugador j = GestionadorUsuarios.GetInstance().GetJugador(usuario);
			Mesa m = JuegoDados.GetInstance().getMesa(idMesa);
			if ( !(m is MesaDados))
				throw new Exception("El juego de dados tiene mesas de NoDados");
			
			try{
				j.entrarAMesa(m);
				escritor.AceptarEntrada(id, usuario, idMesa, "");
			}
			catch (Exception e){
				escritor.DenegarEntrada(id, usuario, idMesa, e.Message);
			}
		}
		public void EntrarCrapsNuevaMesa(int id, string usuario){
			Mesa m = JuegoDados.GetInstance().CrearMesa();
			if ( !(m is MesaDados))
				throw new Exception("El juego de dados tiene mesas de NoDados");
			EntrarCrapsMesa(id, usuario , m.Id);
		}
		
		public void SalirCraps(int id, string usuario, int idMesa){
			Jugador j = GestionadorUsuarios.GetInstance().GetJugador(usuario);
			Mesa m = JuegoDados.GetInstance().getMesa(idMesa);
			try{
				m.quitarParticipante(j);
				escritor.AceptarSalida(id, usuario, idMesa, "");
			}
			catch (Exception e){
				escritor.DenegarSalida(id, usuario, idMesa, e.Message);
			}
			
		}

		public void Apostar(int id, string usuario, int idMesa, 
		               TipoApuestaDados tap, int puntajeApostado, 
		               Dinero valorFichas, int cantidadFichas){
			Jugador j = GestionadorUsuarios.GetInstance().GetJugador(usuario);
			Mesa m = JuegoDados.GetInstance().getMesa(idMesa);
			try{
				ApostarCraps(j,m,tap,puntajeApostado,cantidadFichas,
					valorFichas);
				escritor.ResponderApuestaAceptada(id, usuario, idMesa);
			}
			catch (Exception e){
				escritor.ResponderApuestaDenegada(id, usuario, idMesa);
			}
		}
		private void ApostarCraps(Jugador j, Mesa m, TipoApuestaDados tap, 
		                          int p, int cant, Dinero ficha){
			if ( ! (Casino.GetInstance().GetFichas().Contains(ficha)) ) 
				throw new Exception();
			ApuestaDados a;
			switch(tap){
			case TipoApuestaDados.Pass:
				a = new ApuestaPassNoPass(true, ficha, cant);
				break;
			case TipoApuestaDados.NoPass:
				a = new ApuestaPassNoPass(false, ficha, cant);
				break;
			case TipoApuestaDados.Venir:
				a = new ApuestaVenirNoVenir(true, ficha, cant);
				break;
			case TipoApuestaDados.NoVenir:
				a = new ApuestaVenirNoVenir(false, ficha, cant);
				break;
			case TipoApuestaDados.Campo:
				a = new ApuestaDeCampo(ficha, cant);
				break;
			case TipoApuestaDados.AGanar:
				a = new ApuestaGanarEnContra(true, p, ficha, cant);
				break;
			case TipoApuestaDados.EnContra:
				a = new ApuestaGanarEnContra(false, p, ficha,cant);
				break;
			default:
				throw new Exception();
				a = new ApuestaPassNoPass(true, ficha, cant);
				break;
			}
			m.apostar(j,a);
		}

		public void Tirar(int id, string usuario, int idMesa){
			Jugador j = GestionadorUsuarios.GetInstance().GetJugador(usuario);
			Mesa table = JuegoDados.GetInstance().getMesa(idMesa);
			if (!(table is MesaDados)) throw new Exception("Se intenta tirar en una Mesa de NoDados");
			MesaDados m = (MesaDados)table;
// NO ME FIJO SI EL QUE QUIERE TIRAR ES EL TIRADOR, SOLO QUE ESTÉ EN LA MESA.
			if (m.GetParticipantes().Contains(j)){
				try{
					m.NotificarEstado();
					m.jugar();
					m.NotificarEstado();
					// TODO: ¿Acá no tendría que pedir el resultado? Faltan
					// datos para el escritor.
					
					ResultadoDados res = m.Crupier.UltimoResultado;
					TipoJugada tj = m.Crupier.UltimaJugada;
					escritor.ResponderTiroAceptado(id, usuario, idMesa, res.Dado1, res.Dado2, tj);

				}
				catch(Exception e)
				{
					escritor.ResponderTiroDenegado(id, usuario, idMesa);
				}
			}
			else{
				escritor.ResponderTiroDenegado(id, usuario, idMesa);
			}
		}
		
		public ManejadorDados()
		{
		}

	}
//TODO: Descomentar los llamados al lector de dados
//TODO: Hacer el constructor del manejadorDados o poner todas las funciones static
}
