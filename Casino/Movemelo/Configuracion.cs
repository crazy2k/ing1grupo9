// Configuracion.cs created with MonoDevelop
// User: tas at 11:56 12/08/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.Generic;

namespace Organizador
{
		
	public class Configuracion
	{
		public static readonly string Numero_Grupo = "09";

		public static IList<string> Mensajes_Lectura_Servidor = 
			new List<string>( new string[]{"entradaCasino","salidaCasino","pedidoEstadoCasino",
			"entradaCraps", "salidaCraps", "apuestaCraps", "tiroCraps", 
			"cerrarCasino", "abrirCasino", "rankingCasino", "movimientosJugador",
			"informeEstadoActual", "manipularDados"} );
/*		public static IList<string> Mensajes_Lectura_Administracion = 
			new List<string>(new string[]{ 
			"respuestaEntradaCasinoAdmin","respuestaSalidaCasinoAdmin",
			"respuestaCerrarCasino", "respuestaAbrirCasino", 
			"respuestaRankingCasino", "respuestaMovimientosJugador",
			"respuestaEstadoActual", "respuestaManipularDados"});
		public static IList<string> Mensajes_Lectura_Jugadores =
		new List<string>(new string[]{
            "respuestaEntradaCasino","respuestaSalidaCasino",
			"respuestaEstadoCasino","respuestaEntradaCraps",
			"respuestaSalidaCraps","repuestApuestaCraps","respuestaTiroCraps", 
			"EstadoCraps"});
		
		public static readonly string DIRECTORIO_Lectura_Administracion =
			"\\Temp\\Administracion\\";
		public static readonly string DIRECTORIO_Escritura_Administracion =
			"\\Temp\\";
*/
		public static readonly string DIRECTORIO_Lectura_Servidor = 
			"\\Temp\\Servidor\\";
		public static readonly string DIRECTORIO_Escritura_Servidor = 
			"\\Temp\\";
/*
		public static readonly string DIRECTORIO_Lectura_Jugadores = 
			"\\Temp\\";
		public static readonly string DIRECTORIO_Escritura_Jugadores = 
			"\\Temp\\";
*/	
	}
}
