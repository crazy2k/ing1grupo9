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
    public class Juego
    {
        private List<Mesa> mesas = new List<Mesa>();

        public Mesa getMesa(int id)
        {
            return mesas[id];
        }
        public List<Mesa> getMesas()
        {
            return mesas;
        }
    }
}
