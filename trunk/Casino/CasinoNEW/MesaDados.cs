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

		private Jugada j = new Jugada();

		public MesaDados(int identificador)
		{
			id = identificador;
			reportador  = new ReportadorDados(this);
		}
        public override void jugar() 
        {
            Jugada jugada = GeneradorJugadas.obtenerJugada();
			j = jugada;
			Crupier.pagarApuestas((ResultadoDados)j.getSecond(), (TipoJugada)j.getFirst());
        }
        public override void apostar(Jugador j, Apuesta a) 
        {
            j.agregarApuesta(a);
            Crupier.agregarApuesta(j, a);
        }
        public override void agregarParticipante(Jugador j) 
        {
			Crupier.Tirador = j;
			Crupier.TiradorAnterior = j;
            Anfitrion.recibirParticipante(j);
			EventHandler.agregarObservador(j);
        }
        public override void quitarParticipante(Jugador j) 
        {
            Anfitrion.despedirParticipante(j);
			if (Anfitrion.Participantes.Count == 0) JuegoDados.GetInstance().CerrarMesa(id);
			else if (Crupier.Tirador == j)
				Crupier.Tirador = Anfitrion.Participantes[0];
        }
		public override IList<Jugador> GetParticipantes() {
			return Anfitrion.Participantes;
		}
        public void NotificarEstado() 
        {
            ReporteDados reporte = Reportador.obtenerReporte();
            EventHandler.notificar(reporte);
        }
    }
}
