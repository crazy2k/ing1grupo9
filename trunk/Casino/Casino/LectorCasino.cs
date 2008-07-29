// LectorCasino.cs created with MonoDevelop
// User: pablo at 20:27 28/07/2008
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Casino
{
    class LectorCasino
    {
        private const string DIR = ".\\mensajesCasino\\";

        public void Leer(string archivo)
        {
            string[] partes = archivo.Split(new char[] {'.'});
            string completo = partes[0];
            string mensaje = completo.SubString(0, completo.Length - 6);

            XmlDocument r = new XmlDocument();
            r.load(DIR + archivo);

            switch(mensaje) {
                case "entradaCasino":
                    parsearEntradaCasino(r);
                break;
            }
        }

        private void parsearEntradaCasino(XmlDocument r) {
            XmlElement root = doc.DocumentElement;
            string id = root["vTerm"];
            string usuario = root["usuario"];
            XmlElement ma = root.ChildNodes

        }
    }

}