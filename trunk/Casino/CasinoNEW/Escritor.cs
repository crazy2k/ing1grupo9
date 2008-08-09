using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoNEW
{
	public abstract class Escritor
	{
		private string directorioEscritura = 
			Configuracion.DIRECTORIO_RESPUESTAS_CLIENTE;

		protected string DirectorioEscritura {
			get { return directorioEscritura; }
		}
		protected abstract void Escribir(string nombreArchivo, Object o, 
			int idTerminal);
	}
}
