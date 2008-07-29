using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Collections.Generic;

namespace Casino
{
    public static class EscritorCasino
    {
        public static void escribirGenerico(List<string> info, string archivo)
        {
            XmlTextWriter writer = new XmlTextWriter(archivo,System.Text.Encoding.ASCII);
            writer.WriteDocType("marta", null, null, "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
            foreach (string item in info)
            {
                
            }
        }
    }
}
