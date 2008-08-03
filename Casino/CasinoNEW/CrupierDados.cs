using System;
using System.Configuration;
using System.Collections.Generic;
using Dinero = System.Decimal;

namespace CasinoNEW
{
    public class CrupierDados
    {
        private Jugador tirador;

        public Jugador Tirador
        {
            get { return tirador; }
            set { tirador = value; }
        }

        private Dictionary<Jugador,List<ApuestaDados>> 
            apuestasRealizadas = new Dictionary<Jugador,List<ApuestaDados>>();

		private Dictionary<Jugador, List<ApuestaDados>>
            apuestasPagadas = new Dictionary<Jugador, List<ApuestaDados>>();
        
		private bool esTiroSalida;
        private int punto;
        private ResultadoDados ultimoResultado;
        public void elegirTirador() { }
        
		public void agregarApuesta(Jugador j,Apuesta a)
        {
			//Hay que ver si es de Dados
//            apuestasRealizadas[j].Add(a);
        }

		public void quitarApuesta(Jugador j, ApuestaDados a)
        {
            apuestasRealizadas[j].Remove(a);
        }
		
        public void pagarApuestas(ResultadoDados res, TipoJugada tipo) { 
			foreach (Jugador j in apuestasRealizadas.Keys){
				List<ApuestaDados> aps = apuestasRealizadas[j];
				foreach (ApuestaDados a in aps){
					Pair result = a.evaluar(res);
					bool definida = result.getFirst();
					Dinero valor = result.getSecond();
					if (definida) {
						if (tipo == TodosPonen )
							valor = 
			a.DescontarTodosPonen(Casino.GetInstance().PorcJugadaTodosPonen);
						
						Casino.GetInstance().Pagar(valor, j);
						//Hay que sacarla de las apuestas a pagar y ponerla en
						//las pagadas y fijarse que pasa cuando es feliz
					}
					
					
				
				}
			
			}
		
		}
        public void borrarApuestasPagadas() { }
    }
}
