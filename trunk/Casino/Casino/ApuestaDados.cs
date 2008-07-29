using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Ficha = System.Int32;
using Cantidad = System.Int32;
using Definida = System.Boolean;
using Dinero = System.Decimal;
using EstaDefinidaYDinero = System.Web.UI.Pair;

namespace Casino
{
    public abstract class ApuestaDados: Apuesta
    {
        protected Dictionary<Ficha,Cantidad> fichas;
        protected bool definida;

        public abstract EstaDefinidaYDinero evaluar(ResultadoDados res);
    }
}
