using System;
using System.Configuration;

namespace CasinoNEW
{
    public class Premio
    {
        private decimal montoPremioJugada;
        private decimal montoPremioJF;
        private decimal montoRetencionJTP;
		
		public decimal MontoPremioJugada{
			get{ return montoPremioJugada; }
			set{ montoPremioJugada = value; }
		}		
        public decimal MontoPremioJF{
			get{ return montoPremioJF; }
			set{ montoPremioJF = value; }
		}
        public decimal MontoRetencionJTP{
			get{ return montoRetencionJTP; }
			set{ montoRetencionJTP = value; }
		}
		
        Premio(decimal montoPremioJugada, decimal montoPremioJF,
            decimal montoRetencionJTP) {}
    }
}
