using System;
using System.Configuration;

namespace CasinoNEW
{
    public class ReportadorDados
    {
		public ReportadorDados(MesaDados mesaOriginal){
			mesa = mesaOriginal;
		}
		private MesaDados mesa;
        public void registrarEntradaAMesa(Jugador j) { }//Esto no hace falta al final
        public void caducarApuesta(Apuesta a) { } // Igual que esto
        public void registrarSalidaDeMesa(Jugador j) { } // Y esto
        
		public ReporteDados obtenerReporte() 
        {
			ReporteDados reporte = new ReporteDados();
            reporte.Jugadores = mesa.Anfitrion.Participantes;
			reporte.ProxTirador = mesa.Crupier.Tirador;
			reporte.ProxTiroSalida = mesa.Crupier.EsTiroSalida;
			reporte.ResultadoUltimo = mesa.Crupier.UltimoResultado;
			reporte.UltimoTirador = mesa.Crupier.TiradorAnterior;
			reporte.Premios = mesa.Crupier.premiosPagados();
			reporte.Apuestas = mesa.Crupier.ApuestasRealizadas;
			reporte.Punto = mesa.Crupier.GetPunto();
			reporte.IdMesa = mesa.Id;
			return reporte; //hecho =) (Creo)
        }
    }
}
