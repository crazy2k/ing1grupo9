using System;
using System.Configuration;
using System.Collections.Generic;

namespace CasinoNEW
{
    public abstract class Juego
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
		
		public void CerrarMesa(int mesa)
		{
			mesas--;
			foreach(Mesa m in mesas){
				if (m.getid() == mesa)
					mesas.remove(m);
			}
		}
		
		public abstract Mesa CrearMesa();
		public abstract void Reset();
    }
}
