using System;
using System.Configuration;
using Dinero = System.Decimal;

namespace CasinoNEW
{
    public abstract class Apuesta
    {
        #region variables

        protected Dinero valor;
        protected Premio premio;

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
			premio.MontoPremioJugada -= diff;
			return (premio.MontoPremioJugada-diff);
		}
    }
}
