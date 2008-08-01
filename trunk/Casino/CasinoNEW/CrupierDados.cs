using System;
using System.Configuration;
using System.Collections.Generic;

namespace CasinoNEW
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
