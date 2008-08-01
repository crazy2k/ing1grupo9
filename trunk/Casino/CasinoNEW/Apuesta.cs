using System;
using System.Configuration;

namespace CasinoNEW
{
    public abstract class Apuesta
    {
        #region variables

        protected decimal valor;
        protected Premio premio;

        #endregion

        #region getters

        public decimal getValor()
        {
            return valor;
        }

        #endregion
    }
}
