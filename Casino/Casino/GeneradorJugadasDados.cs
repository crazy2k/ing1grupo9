using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Jugada = System.Web.UI.Pair;

namespace Casino
{
    public class GeneradorJugadasDados
    {
        private Pair proxJugada;

        public Jugada obtenerJugada()
        {
            return proxJugada;
        }
        public void setTipoJugada(TipoJugada t)
        {
            proxJugada.First = t;
        }
        public void setResultado(ResultadoDados r)
        {
            proxJugada.Second = r;
        }
    }
}
