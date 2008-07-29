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
    public class Jugador
    {
        #region variables 

        private decimal credito;
        private string nombre;
        private List<Apuesta> apuestas = new List<Apuesta>();

        #endregion

        #region funciones 

        Jugador(string usuario, decimal dinero) 
        {
            nombre = usuario;
            credito = dinero;
        }
        public void pagar(decimal costo)
        {
            credito -= costo;
        }
        public void cobrar(decimal ganancia)
        {
            credito += ganancia;
        }
        public void recibirApuesta(Apuesta a)
        {
            apuestas.Add(a);
        }

        #endregion
    }
}
