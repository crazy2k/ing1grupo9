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
			decimal diff = (decimal)(g*porcentaje);
			premio.MontoRetencionJTP = diff;
			//premio.MontoPremioJugada -= diff; esto no va =P
			return (premio.MontoPremioJugada-diff);
		}

        public Dinero AgregarAdicionalFeliz(Dinero montoTotal, Dinero pozoFeliz)
        {
            premio.MontoPremioJF = (premio.MontoPremioJugada / montoTotal) * pozoFeliz;
            return premio.MontoPremioJF;
        }
    }
}
