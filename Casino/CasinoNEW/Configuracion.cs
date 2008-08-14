// Configuracion.cs created with MonoDevelop
// User: pablo at 12:39 PM 7/30/2008
//

using System;

namespace CasinoNEW
{
	
	
	public class Configuracion
	{
		public static readonly string ARCHIVO_USUARIOS = 
			"\\Temp\\lista-usuarios.txt";
		public static readonly string ARCHIVO_CONFIG =
			"\\Temp\\configuracion-casino.txt";
		
		// Estas opciones de configuración quedan por si en algún momento
		// alguien desea hacer una modificación.
		//Los siguientes son todos directorios de escritura
		public static readonly string DIRECTORIO_accesoYVistaCasino = 
			"\\Temp\\";
		public static readonly string DIRECTORIO_accesoCasinoAdminManip = 
			"\\Temp\\";
		public static readonly string DIRECTORIO_administracion =
			"\\Temp\\";
		public static readonly string DIRECTORIO_RESPUESTAS_CLIENTE = 
			"\\Temp\\";
		public static readonly string DIRECTORIO_Dados =
			"\\Temp\\";
		public static readonly string DIRECTORIO_Manipulacion =
			"\\Temp\\";
		//Este es el directorio del que lee el servidor
		public static readonly string DIRECTORIO_Lectura = "\\Temp\\Servidor\\";
		
		public static readonly int NUMERO_GRUPO = 9;

	}
		
}
