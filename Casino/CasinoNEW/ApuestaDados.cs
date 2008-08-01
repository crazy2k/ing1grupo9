using System;
using System.Configuration;
using System.Collections.Generic;
using Ficha = System.Int32;
using Cantidad = System.Int32;
using Definida = System.Boolean;
using Dinero = System.Decimal;

namespace CasinoNEW
{
    public abstract class ApuestaDados: Apuesta
    {
        protected Dictionary<Ficha,Cantidad> fichas;
        protected bool definida;

        public abstract Pair evaluar(ResultadoDados res);
    }
}
