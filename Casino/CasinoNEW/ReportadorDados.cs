using System;
using System.Configuration;

namespace CasinoNEW
{
    public class ReportadorDados
    {
        public void registrarEntradaAMesa(Jugador j) { }
        public void caducarApuesta(Apuesta a) { }
        public void registrarSalidaDeMesa(Jugador j) { }
        public ReporteDados obtenerReporte() 
        {
            return new ReporteDados(); //hacer =)
        }
    }
}
