using System;
using System.Collections.Generic;
using System.Text;

using Dinero = System.Decimal;

namespace CasinoNEW
{
	class ManejadorAdministracion
	{
		private EscritorAdministracion escritor = 
			new EscritorAdministracion();

		private GeneradorInformes ginformes =
			new GeneradorInformes();

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

		public void PedirRankingCasino(int id, string usuario, 
			string tipoRanking, int longitud)
		{
			GestionadorUsuarios g = GestionadorUsuarios.GetInstance();
			try
			{
				// En realidad, no uso al administrador. Sólo lo
				// pido para saber si el usuario está autenticado
				// como administrador.
				// TODO: ¿Rever?
				Administrador a = g.GetAdmin(usuario);

				IList<UsuarioConSaldo> lucs =
					ginformes.Ranking(tipoRanking, longitud);

				escritor.InformarRanking(id, usuario, lucs);
			}
			// No distingo las excepciones porque el protocolo
			// ni siquiera tiene la opción de enviar un motivo
			// para denegar la operación.
			catch (Exception e)
			{
				escritor.DenegarRankingCasino(id, usuario);
			}
		}

		public void PedirEstadoActual(int id, string usuario)
		{
			GestionadorUsuarios g = GestionadorUsuarios.GetInstance();
			try
			{
				// En realidad, no uso al administrador. Sólo lo
				// pido para saber si el usuario está autenticado
				// como administrador.
				// TODO: ¿Rever?
				Administrador a = g.GetAdmin(usuario);

				EstadoCasino ec = ginformes.EstadoActual();

				IList<UsuarioConSaldo> lucs = ec.usuariosConSaldo;
				Dinero saldo = ec.saldoCasino;

				escritor.InformarEstadoActual(id, usuario, saldo, lucs);
			}
			// No distingo las excepciones porque el protocolo
			// ni siquiera tiene la opción de enviar un motivo
			// para denegar la operación.
			catch (Exception e)
			{
				escritor.DenegarEstadoActual(id, usuario);
			}
		}

		public void PedirMovimientosPorJugador(int id, string usuario,
			string jugador)
		{
			GestionadorUsuarios g = GestionadorUsuarios.GetInstance();
			try
			{
				// En realidad, no uso al administrador. Sólo lo
				// pido para saber si el usuario está autenticado
				// como administrador.
				// TODO: ¿Rever?
				Administrador a = g.GetAdmin(usuario);

				IList<ValorPremios> lvps =
					ginformes.MovimientosPorJugador(jugador);

				escritor.InformarMovimientosPorJugador(id, usuario, lvps, jugador);
			}
			// No distingo las excepciones porque el protocolo
			// ni siquiera tiene la opción de enviar un motivo
			// para denegar la operación.
			catch (Exception e)
			{
				escritor.DenegarMovimientosPorJugador(id, usuario);
			}
		}


	}
}
