using System;
using System.Configuration;

namespace CasinoNEW
{
    public abstract class Mesa
    {
        protected int id;
		
		public int Id {
			get { return id; }
			set { id = value; }
		}

        public abstract void jugar();
        public abstract void agregarParticipante(Jugador j);
        public abstract void quitarParticipante(Jugador j);
        public abstract void apostar(Jugador j, Apuesta a);
    }
}
