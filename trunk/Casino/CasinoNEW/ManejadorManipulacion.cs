using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoNEW
{
	class ManejadorManipulacion
	{

		private EscritorManipulacion escritor = new EscritorManipulacion();

		public void ManipularMesaDados(int id, string usuario, int dado1,
			int dado2, TipoJugada tj)
		{
			GestionadorUsuarios g = GestionadorUsuarios.GetInstance();
			try
			{
				// En realidad, no uso al manipulador. Sólo lo
				// pido para saber si el usuario está autenticado
				// como manipulador.
				// TODO: ¿Rever?
				Manipulador m = g.GetManip(usuario);

				m.manipularResultado(new ResultadoDados(dado1, dado2),
					JuegoDados.GetInstance().getMesas());

				escritor.AceptarManipulacionDados(id, usuario);
			}
			// No distingo las excepciones porque el protocolo
			// ni siquiera tiene la opción de enviar un motivo
			// para denegar la operación.
			catch (Exception e)
			{
				escritor.DenegarManipulacionDados(id, usuario);
			}
		}
	}
}
