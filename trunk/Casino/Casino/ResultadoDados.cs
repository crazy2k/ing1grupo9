using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Casino
{
    public class ResultadoDados: Resultado
    {
        private int Dado1;
        private int Dado2;
    
    public int sumaDados()
        {
            return Dado1+Dado2;
        }
    }
}
