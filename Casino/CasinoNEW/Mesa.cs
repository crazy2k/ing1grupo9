using System;
using System.Configuration;

namespace CasinoNEW
{
    public abstract class Mesa
    {
        private int id; //sacarlo

        public abstract void jugar();
        public abstract void agregarParticipante(Jugador j);
        public abstract void quitarParticipante(Jugador j);
    }
}
