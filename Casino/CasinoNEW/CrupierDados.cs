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
            set { TiradorAnterior = value; }
        }

        private Dictionary<Jugador,List<ApuestaDados>> 
            apuestasRealizadas = new Dictionary<Jugador,List<ApuestaDados>>();

		private Dictionary<Jugador, List<ApuestaDados>>
            apuestasPagadas = new Dictionary<Jugador, List<ApuestaDados>>();
        
		private bool esTiroSalida;
        private int punto;
        private ResultadoDados ultimoResultado;
        public void elegirTirador() { }

		public ResultadoDados UltimoResultado {
			get { return ultimoResultado; }
		}
		
		public int GetPunto() {
			return punto;
		}
		
		public bool EsTiroSalida() {
			return esTiroSalida;
		}
        
		public void agregarApuesta(Jugador j,Apuesta a)
        {
			//Veo si la apuesta es de dados es de Dados
			if (a is ApuestaDados) throw new Exception("La apuesta no es de Dados.");
			ApuestaDados apuesta = (ApuestaDados)a;
            apuestasRealizadas[j].Add(apuesta);
        }

		public void quitarApuesta(Jugador j, ApuestaDados a)
        {
            apuestasRealizadas[j].Remove(a);
        }
		
		private void pagarAdicionalFeliz(Dinero total){
			Decimal pozo = Casino.GetInstance().TomarPozoFeliz();
						
			foreach (Jugador j in apuestasPagadas.Keys){
				List<ApuestaDados> aps = apuestasPagadas[j];
				foreach (ApuestaDados a in aps){
					Decimal pago = a.AgregarAdicionalFeliz(total, pozo);
					Casino.GetInstance().Pagar(pago, j);
				}
			}
		}
		
        public void pagarApuestas(ResultadoDados res, TipoJugada tipo) {
			Dinero totalPagado = 0;
						
			borrarApuestasPagadas();
						
			foreach (Jugador j in apuestasRealizadas.Keys){
				List<ApuestaDados> aps = apuestasRealizadas[j];
				foreach (ApuestaDados a in aps){
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
						if (aps.Count == 0)
							apuestasRealizadas.Remove(j);
						// Hasta acá lo saco de las realizadas
						if (apuestasPagadas.ContainsKey(j)){
							aps = apuestasPagadas[j];
							aps.Add(a);
						}
						else{
							aps = new List<ApuestaDados>();
							aps.Add(a);
							apuestasPagadas.Add(j,aps);
						}
						// Ahora la puse en las pagadas
						totalPagado += valor;
						// Esto lo uso sólo cuando la jugada es feliz, 
						// sino no se usa para nada. Lo había puesto adentro
						// de un if, pero al ser tan poco prefiero hacer todas
						// las veces esto a un if. =P
					}
					// Si no está definida hago nada...				
				}
				// Sigo con el próximo jugador...
			} 
			//Cuando termino con todos los jugadores...
			if ( tipo == TipoJugada.Feliz )
				pagarAdicionalFeliz(totalPagado);			
		}
		
        public void borrarApuestasPagadas() {
			apuestasPagadas.Clear();
		}
    }
}
