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

namespace Casino
{
    public class CrupierDados
    {
        private Jugador Tirador;
        private Dictionary<Jugador,List<ApuestaDados>> 
            apuestasRealizadas = new Dictionary<Jugador,List<ApuestaDados>>();

        public void agregarApuesta(Jugador j,ApuestaDados a)
        {
            apuestasRealizadas[j].Add(a);
        }
    }
}
