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
    public class AnfitrionDados
    {
        private List<Jugador> participantes = new List<Jugador>();
        
        public void recibirParticipante(Jugador j) 
        {
            participantes.Add(j);
        }
        public void despedirParticipante(Jugador j) 
        {
            participantes.Remove(j);
        }
    }
}
