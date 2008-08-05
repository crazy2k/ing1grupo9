using System;
using System.Configuration;
using System.Collections.Generic;
using Jugada = CasinoNEW.Pair;

namespace CasinoNEW
{
    public class MesaDados : Mesa
    {
        private AnfitrionDados anfitrion = new AnfitrionDados();

        public AnfitrionDados Anfitrion
        {
			get { return anfitrion; }
			set { anfitrion = value; }
		}

        private GeneradorJugadasDados generadorJugadas = new GeneradorJugadasDados();

        public GeneradorJugadasDados GeneradorJugadas
        {
            get { return generadorJugadas; }
            set { generadorJugadas = value; }
        }

        private EventHandlerDados eventHandler = new EventHandlerDados();

        public EventHandlerDados EventHandler
        {
            get { return eventHandler; }
            set { eventHandler = value; }
        }

        private ReportadorDados reportador;

        public ReportadorDados Reportador
        {
            get { return reportador; }
            set { reportador = value; }
        }

        private CrupierDados crupier = new CrupierDados();

        public CrupierDados Crupier
        {
            get { return crupier; }
            set { crupier = value; }
        }

		public MesaDados(int identificador)
		{
			id = identificador;
			reportador  = new ReportadorDados(this);
		}
        public override void jugar() 
        {
            Jugada jugada = GeneradorJugadas.obtenerJugada();
            Crupier.pagarApuestas((ResultadoDados)jugada.getFirst(),(TipoJugada)jugada.getSecond());
        }
        public override void apostar(Jugador j, Apuesta a) 
        {
            j.agregarApuesta(a);
            Crupier.agregarApuesta(j, a);
        }
        public override void agregarParticipante(Jugador j) 
        {
            Anfitrion.recibirParticipante(j);
        }
        public override void quitarParticipante(Jugador j) 
        {
            Anfitrion.despedirParticipante(j);
        }
		public override IList<Jugador> GetParticipantes() {
			return Anfitrion.Participantes;
		}
        public void notificarEstado() 
        {
            ReporteDados reporte = Reportador.obtenerReporte();
            EventHandler.notificar(reporte);
        }
    }
}
