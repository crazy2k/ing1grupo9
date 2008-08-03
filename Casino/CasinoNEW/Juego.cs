using System;
using System.Configuration;
using System.Collections.Generic;
using Dinero = System.Decimal;

namespace CasinoNEW
{
    public abstract class Juego
    {
        protected List<Mesa> mesas = new List<Mesa>();
		private string nombre;

        public Mesa getMesa(int id)
        {
            return mesas[id];
        }
        public List<Mesa> getMesas()
        {
            return mesas;
        }
		
		public abstract Mesa CrearMesa();
		public abstract void Reset();
		
		public string Nombre {
			get { return nombre; }
			set { nombre = value; }
		}
    }
}
