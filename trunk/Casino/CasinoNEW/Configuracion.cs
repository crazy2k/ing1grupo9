// Configuracion.cs created with MonoDevelop
// User: pablo at 12:39 PM 7/30/2008
//

using System;

namespace CasinoNEW
{
	
	
	public class Configuracion
	{
		public static string ARCHIVO_USUARIOS = 
			"./lista-usuarios.txt";
		public static readonly string ARCHIVO_CONFIG = 
			"./configuracion-casino.txt";
		
		// Se leen los mensajes y se escriben en \\Temp\\. Estas opciones de
		// configuración quedan por si en algún momento alguien desea hacer
		// una modificación.
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

		public static readonly int NUMERO_GRUPO = 9;

	}
		
}
