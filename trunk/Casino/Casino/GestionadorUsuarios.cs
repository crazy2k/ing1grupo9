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
    public class GestionadorUsuarios
    {
        #region variables

        private static volatile GestionadorUsuarios instance;
        private static object syncRoot = new Object();
        private List<Jugador> jugadoresActivos = new List<Jugador>();

        #endregion

        #region funciones

        private GestionadorUsuarios() {}
        public static GestionadorUsuarios getInstance()
        {
             if (instance == null) 
             {
                lock (syncRoot) 
                {
                   if (instance == null) 
                      instance = new GestionadorUsuarios();
                }
             }
             return instance;
        }
        public List<Jugador> getJugadoresActivos()
        {
            return jugadoresActivos;
        }
        public void add(Jugador j)
        {
            jugadoresActivos.Add(j);
        }
        public void remove(Jugador j)
        {
            jugadoresActivos.Remove(j);
        }

        #endregion
    }
}
