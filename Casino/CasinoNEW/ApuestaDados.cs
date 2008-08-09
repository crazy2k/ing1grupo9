using System;
using System.Configuration;
using System.Collections.Generic;
using Ficha = System.Decimal;
using Cantidad = System.Int32;
using Definida = System.Boolean;
using Dinero = System.Decimal;

namespace CasinoNEW
{
    public abstract class ApuestaDados: Apuesta
    {
        protected Dictionary<Ficha,Cantidad> fichas;
        protected bool definida = false;

		public Dictionary<Ficha, Cantidad> Fichas
		{
			get { return fichas; }
		}

        public abstract Pair evaluar(ResultadoDados res);

    }
}
