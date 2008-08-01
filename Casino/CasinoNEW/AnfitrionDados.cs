using System;
using System.Configuration;
using System.Collections.Generic;

namespace CasinoNEW
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
