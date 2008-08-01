using System;
using System.Configuration;

namespace CasinoNEW
{
    public abstract class Mesa
    {
        protected int id; //sacarlo
		
		public int Id {
			get { return id; }
			set { id = value; }
		}

        public abstract void jugar();
        public abstract void agregarParticipante(Jugador j);
        public abstract void quitarParticipante(Jugador j);
    }
}
