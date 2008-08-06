using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoNEW
{
	class ManejadorAdministracion
	{
		private EscritorAdministracion escritor = 
			new EscritorAdministracion();

		public void CerrarCasino(int id, string usuario)
		{
			GestionadorUsuarios g = GestionadorUsuarios.GetInstance();
			try
			{
				Administrador a = g.GetAdmin(usuario);
				a.CerrarCasino();

				escritor.AceptarCerrarCasino(id, usuario);
			}
			// No distingo las excepciones porque el protocolo
			// ni siquiera tiene la opción de enviar un motivo
			// para denegar la operación.
			catch (Exception e)
			{
				escritor.DenegarCerrarCasino(id, usuario);
			}
		}

		public void AbrirCasino(int id, string usuario)
		{
			GestionadorUsuarios g = GestionadorUsuarios.GetInstance();
			try
			{
				Administrador a = g.GetAdmin(usuario);
				a.AbrirCasino();

				escritor.AceptarAbrirCasino(id, usuario);
			}
			// No distingo las excepciones porque el protocolo
			// ni siquiera tiene la opción de enviar un motivo
			// para denegar la operación.
			catch (Exception e)
			{
				escritor.DenegarAbrirCasino(id, usuario);
			}
		}

	}
}
