using System;
using System.Configuration;
using System.Collections.Generic;

namespace CasinoNEW
{
    public class EventHandlerDados
    {
		private IList<Terminal> terminales = new List<Terminal>();
		public void agregarObservador(Jugador j) {
			Terminal t = new Terminal(j);
			terminales.Add(t);
		}

        public void quitarObservador(Jugador j) {
			foreach (Terminal t in terminales){
				if (t.Observador == j) terminales.Remove(t);
			}
		}
		
        public void notificar(ReporteDados rep) {
			foreach (Terminal t in terminales){
				t.Notificar(rep);
			}
		}
    }
}
