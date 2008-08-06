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
			catch (NoAdministradorException e)
			{
				escritor.DenegarCerrarCasino(id, usuario);
			}
		}

	}
}
