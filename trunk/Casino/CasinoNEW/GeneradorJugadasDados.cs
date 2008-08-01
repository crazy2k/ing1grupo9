using System;
using System.Configuration;

namespace CasinoNEW
{
    public class GeneradorJugadasDados
    {
        private Pair proxJugada;

        public Pair obtenerJugada()
        {
            return proxJugada;
        }
        public void setTipoJugada(TipoJugada t)
        {
            proxJugada.setFirst(t);
        }
        public void setResultado(ResultadoDados r)
        {
            proxJugada.setSecond(r);
        }
    }
}
