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
    public static class LectorCasino
    {
        public static List<string> leerGenerico(string archivo)
        {
            XmlTextReader reader = new XmlTextReader(archivo);
            List<string> parametros = new List<string>();
            string param;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: 
                        if (reader.AttributeCount > 0)
                        {
                            reader.MoveToFirstAttribute();
                            param = reader.Value;
                            parametros.Add(param);
                            while (reader.MoveToNextAttribute()) 
                            {
                                param = reader.Value;
                                parametros.Add(param);
                            }
                        }
                        break;
                    case XmlNodeType.Text:
                        param = reader.Value;
                        parametros.Add(param);
                        break;
                }

            }
            return parametros;
        }
    }
}
