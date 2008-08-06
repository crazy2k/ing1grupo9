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
		public static void Notificar(int id, string usuario, int idMesa, 
		                      IList<Jugador> jugadores, Jugador proxTirador,
		                      bool proxTiroSalida, int punto, 
		                      Jugador ultimoTirador, Resultado ultimoResultado, 
		                      IList<Premio> premios, 
		                     Dictionary<Jugador,IList<ApuestaDados>> apuestas){}
		
	
		public void EntrarCrapsMesa(int id, string usuario, int idMesa){
			Jugador j = GestionadorUsuarios.GetInstance().GetJugador(usuario);
			Mesa m = JuegoDados.GetInstance().getMesa(idMesa);
			if ( !(m is MesaDados))
				throw new Exception("El juego de dados tiene mesas de NoDados");
//			EscritorDados escr = EscritorDados.GetInstance();
			try{
				j.entrarAMesa(m);
//				escr.AceptarEntrada(id,usuario,idMesa, "");
			}
			catch (Exception e){
//				escr.DenegarEntrada(id, usuario, idMesa, e.Message);
			}
		}
		public void EntrarCrapsNuevaMesa(int id, string usuario){
			Mesa m = JuegoDados.GetInstance().CrearMesa();
			if ( !(m is MesaDados))
				throw new Exception("El juego de dados tiene mesas de NoDados");
			EntrarCrapsMesa(id, usuario , m.Id);
		}
		
		public void SalirCraps(int id, string usuario, int idMesa){
			
		}

		public void Apostar(int id, string usuario, int idMesa, 
		               TipoApuestaDados tap, int puntajeApostado, 
		               Dinero valorFichas, int cantidadFichas){
			Jugador j = GestionadorUsuarios.GetInstance().GetJugador(usuario);
			Mesa m = JuegoDados.GetInstance().getMesa(idMesa);
			try{
				ApostarCraps(j,m,tap,puntajeApostado,cantidadFichas,valorFichas);
//				EscritorDados.GetInstance().ResponderApuestaAceptada(id,
//				                                              usuario, idMesa);
			}
			catch (Exception e){
//				EscritorDados.GetInstance().ResponderApuestaDenegada(id,
//				                                              usuario, idMesa);
			}
		}
		private void ApostarCraps(Jugador j, Mesa m, TipoApuestaDados tap, 
		                          int p, int cant, Dinero ficha){
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
				a = new ApuestaPassNoPass(true, ficha, cant);
				break;
			}
			m.apostar(j,a);
		}

		public void Tirar(int id, string usuario, int idMesa){}
		
		public ManejadorDados()
		{
		}
	}
}
