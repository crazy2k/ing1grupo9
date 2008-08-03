using System;
using System.Configuration;
using System.Collections.Generic;

namespace CasinoNEW
{
    public class CrupierDados
    {
        private Jugador tirador;

        public Jugador Tirador
        {
            get { return tirador; }
            set { tirador = value; }
        }

        private Dictionary<Jugador,List<Apuesta>> 
            apuestasRealizadas = new Dictionary<Jugador,List<Apuesta>>();
        private Dictionary<Jugador, List<Apuesta>>
            apuestasPagadas = new Dictionary<Jugador, List<Apuesta>>();
        private bool esTiroSalida;
        private int punto;
        private ResultadoDados ultimoResultado;
        public void elegirTirador() { }
        public void agregarApuesta(Jugador j,Apuesta a)
        {
            apuestasRealizadas[j].Add(a);
        }
        public void quitarApuesta(Jugador j, Apuesta a)
        {
            apuestasRealizadas[j].Remove(a);
        }
        public void pagarApuestas(ResultadoDados res, TipoJugada tipo) { }
        public void borrarApuestasPagadas() { }
    }
}
