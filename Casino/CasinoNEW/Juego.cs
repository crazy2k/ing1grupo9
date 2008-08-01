using System;
using System.Configuration;
using System.Collections.Generic;

namespace CasinoNEW
{
    public class Juego
    {
        private List<Mesa> mesas = new List<Mesa>();

        public Mesa getMesa(int id)
        {
            return mesas[id];
        }
        public List<Mesa> getMesas()
        {
            return mesas;
        }
    }
}
