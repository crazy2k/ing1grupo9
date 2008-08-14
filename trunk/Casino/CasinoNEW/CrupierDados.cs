using System;
using System.Configuration;
using System.Collections.Generic;
using Dinero = System.Decimal;

namespace CasinoNEW
{
    public class CrupierDados
    {
        private Jugador tirador;
		private Jugador tiradorAnterior;

        public Jugador Tirador
        {
            get { return tirador; }
            set { tirador = value; }
        }
		
		public Jugador TiradorAnterior
        {
            get { return tiradorAnterior; }
            set { tiradorAnterior = value; }
        }

        private Dictionary<Jugador,IList<ApuestaDados>> 
            apuestasRealizadas = new Dictionary<Jugador,IList<ApuestaDados>>();
		public Dictionary<Jugador,IList<ApuestaDados>> ApuestasRealizadas{
			get{return apuestasRealizadas;}
		}

		private Dictionary<Jugador, IList<ApuestaDados>>
            apuestasPagadas = new Dictionary<Jugador, IList<ApuestaDados>>();

		public Dictionary<Jugador, IList<Premio>> premiosPagados()
		{
			Dictionary<Jugador, IList<Premio>> premiosPagad = new Dictionary<Jugador,IList<Premio>>();
			IList<Premio> premios;
			foreach (Jugador j in apuestasPagadas.Keys){
				premios = new List<Premio>();
				IList<ApuestaDados> aps = apuestasPagadas[j];
				foreach (ApuestaDados a in aps){
					premios.Add(a.Premio);
				}
				premiosPagad.Add(j,premios);
//				premios.Clear();
			}
			return premiosPagad;
		}
		
		
		private bool esTiroSalida = true;
        private int punto = 0;
        private ResultadoDados ultimoResultado;
		private TipoJugada ultimaJugada;
        //public void elegirTirador() { } 
		// Este dijo Marta que dijeron que no lo hagamos

		public ResultadoDados UltimoResultado {
			get { return ultimoResultado; }
		}
		public TipoJugada UltimaJugada
		{
			get { return ultimaJugada; }
		}
		
		public int GetPunto() {
			return punto;
		}
		
		public bool EsTiroSalida {
			get{return esTiroSalida;}
		}
        
		public void agregarApuesta(Jugador j,Apuesta a)
        {
			//Veo si la apuesta es de dados es de Dados
			if (!(a is ApuestaDados)) throw new Exception("La apuesta no es de Dados.");
			ApuestaDados apuesta = (ApuestaDados)a;
			if (!ApuestasRealizadas.ContainsKey(j))
				ApuestasRealizadas.Add(j, new List<ApuestaDados>());
			apuestasRealizadas[j].Add(apuesta);
			Casino.GetInstance().Cobrar(apuesta.getValor(),j);
		}

		public void quitarApuesta(Jugador j, ApuestaDados a)
        {
            apuestasRealizadas[j].Remove(a);
        }
		
		private void pagarAdicionalFeliz(Dinero total){
			Decimal pozo = Casino.GetInstance().TomarPozoFeliz();
						
			foreach (Jugador j in apuestasPagadas.Keys){
				IList<ApuestaDados> aps = apuestasPagadas[j];
				foreach (ApuestaDados a in aps){
					Decimal pago = a.AgregarAdicionalFeliz(total, pozo);
					Casino.GetInstance().Pagar(pago, j);
				}
			}
		}
		
        public void pagarApuestas(ResultadoDados res, TipoJugada tipo) {
			ultimaJugada = tipo;
			if (esTiroSalida){
				if(res.sumaDados() != 2 && res.sumaDados() != 3 
				  && res.sumaDados() != 7 && res.sumaDados() != 11 
				  && res.sumaDados() != 12 ){
					esTiroSalida = false;
					punto = res.sumaDados();
				}
			}
			else{
				if (punto == res.sumaDados() || res.sumaDados() == 7){
					esTiroSalida = true;
					punto = 0;
				}
			}

			ultimoResultado=res;
			Dinero totalPagado = 0;
						
			borrarApuestasPagadas();

			Dictionary<Jugador, IList<ApuestaDados>> nuevasApuestas =
				new Dictionary<Jugador, IList<ApuestaDados>>();

			IList<ApuestaDados> aps;
			foreach (Jugador j in apuestasRealizadas.Keys){
				aps = new List<ApuestaDados>(apuestasRealizadas[j]);
				foreach (ApuestaDados a in apuestasRealizadas[j]){
					Pair result = a.evaluar(res);
					bool definida = (bool)result.getFirst();
					Dinero valor = (Dinero)result.getSecond();
					if (definida) {
						if (tipo == TipoJugada.TodosPonen )
							valor = 
			a.DescontarTodosPonen(Casino.GetInstance().PorcJugadaTodosPonen);
						
						Casino.GetInstance().Pagar(valor, j);
						//Hay que sacarla de las apuestas a pagar y ponerla en
						//las pagadas y fijarse que pasa cuando es feliz
						aps.Remove(a);
						
						// Hasta acá lo saco de las realizadas
						if (apuestasPagadas.ContainsKey(j)){
							apuestasPagadas[j].Add(a);
						}
						else{
							IList<ApuestaDados> apsTemp = new List<ApuestaDados>();
							apsTemp.Add(a);
							apuestasPagadas.Add(j,apsTemp);
						}
						// Ahora la puse en las pagadas
						totalPagado = totalPagado + valor;
						// Esto lo uso sólo cuando la jugada es feliz, 
						// sino no se usa para nada. Lo había puesto adentro
						// de un if, pero al ser tan poco prefiero hacer todas
						// las veces esto a un if. =P
					}
					// Si no está definida hago nada...				
				}
				if (aps.Count > 0)
					nuevasApuestas.Add(j, aps);
				aps.Clear();
				
				// Sigo con el próximo jugador...
			}
			apuestasRealizadas = nuevasApuestas;
			/*
			foreach (Jugador jug in jugadoresASacar)
			{
				apuestasRealizadas.Remove(jug);
			}
			jugadoresASacar.Clear();
			*/

			//Cuando termino con todos los jugadores...
			if ( tipo == TipoJugada.Feliz )
				pagarAdicionalFeliz(totalPagado);			
		}
		
        public void borrarApuestasPagadas() {
			apuestasPagadas.Clear();
		}
    }
}
