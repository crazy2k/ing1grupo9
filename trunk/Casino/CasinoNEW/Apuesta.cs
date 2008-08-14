using System;
using System.Configuration;
using Dinero = System.Decimal;

namespace CasinoNEW
{
    public abstract class Apuesta
    {
        #region variables

        protected Dinero valor;
        protected Premio premio = new Premio();
		public Premio Premio{
			get{return premio;}
			
		}

        #endregion

        #region getters

        public Dinero getValor()
        {
            return valor;
        }

        #endregion

		public Dinero DescontarTodosPonen(float porcentaje)
		{
			double g = (double)premio.MontoPremioJugada;
			Dinero diff = (Dinero)(g*porcentaje);
			premio.MontoRetencionJTP = diff;
			//premio.MontoPremioJugada -= diff; esto no va =P
			return ((premio.MontoPremioJugada) - diff);
		}

        public Dinero AgregarAdicionalFeliz(Dinero montoTotal, Dinero pozoFeliz)
        {
			if (montoTotal != 0)
				premio.MontoPremioJF = (premio.MontoPremioJugada / montoTotal) * pozoFeliz;
			else
				premio.MontoPremioJF = 0;
            return premio.MontoPremioJF;
        }
    }
}
