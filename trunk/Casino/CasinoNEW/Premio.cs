using System;
using System.Configuration;
using Dinero = System.Decimal;

namespace CasinoNEW
{
    public class Premio
    {
        private Dinero montoPremioJugada;
        private Dinero montoPremioJF;
        private Dinero montoRetencionJTP;

        public Premio()
        {
        }

		public Dinero MontoPremioJugada{
			get{ return montoPremioJugada; }
			set{ montoPremioJugada = value; }
		}		
        public Dinero MontoPremioJF{
			get{ return montoPremioJF; }
			set{ montoPremioJF = value; }
		}
        public Dinero MontoRetencionJTP{
			get{ return montoRetencionJTP; }
			set{ montoRetencionJTP = value; }
		}
		
        public Premio(Dinero montoPremioJugada, Dinero montoPremioJF,
            Dinero montoRetencionJTP) {}
    }
}
