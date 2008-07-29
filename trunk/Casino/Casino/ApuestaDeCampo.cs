using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using EstaDefinidaYDinero = System.Web.UI.Pair;

namespace Casino
{
    public class ApuestaDeCampo : ApuestaDados
    {
        public override EstaDefinidaYDinero evaluar(ResultadoDados res)
        {
            decimal premio;
            if (res.sumaDados() == 3 || res.sumaDados() == 4 || res.sumaDados() == 9 || 
                res.sumaDados() == 10 || res.sumaDados() == 11) 
            { 
                premio = valor*2;
            }
            else if (res.sumaDados() == 2 || res.sumaDados() == 12) 
            { 
                premio = valor*3;
            } 
            else 
            { 
                premio = 0; 
            }
            return new Pair(true, premio);
        }
    }
}
