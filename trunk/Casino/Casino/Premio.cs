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
    public class Premio
    {
        private decimal montoPremioJugada;
        private decimal montoPremioJF;
        private decimal montoRetencionJTP;

        Premio(decimal montoPremioJugada, decimal montoPremioJF,
            decimal montoRetencionJTP) {}
    }
}
