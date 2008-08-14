using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using Dinero = System.Decimal;



namespace CasinoNEW
{
	public struct UsuarioConSaldo
	{
		public string nombre;
		public Dinero saldo;
	}

	public struct EstadoCasino
	{
		public IList<UsuarioConSaldo> usuariosConSaldo;
		public Dinero saldoCasino;
	}

	public struct ValorPremios
	{
		public Dinero valorApuesta;
		public MontosPremio montos;
	}

	public struct MontosPremio
	{
		public Dinero premioJugada;
		public Dinero montoFeliz;
		public Dinero montoTodosPonen;
	}


	public class GeneradorInformes
	{
		public IList<UsuarioConSaldo> Ranking(string tipoRanking,
			int longitud)
		{
			VerificarClausura();
			GestionadorUsuarios g = GestionadorUsuarios.GetInstance();

			// Horrible, pero no queda otra.
			List<Jugador> js = (List<Jugador>)g.JugadoresInactivos;
	
			js.Sort(delegate(Jugador j1, Jugador j2) {
				return j1.Credito.CompareTo(j2.Credito); });

			tipoRanking = tipoRanking.ToLower();

			if (tipoRanking == "ganadores")
				js.Reverse();
			
			// Le quito los elementos que no necesito devolver.
			if (longitud < js.Count)
				js.RemoveRange(longitud, js.Count - 1);

			IList<UsuarioConSaldo> lucs = ToWritable(js);

			return lucs;
		}

		private IList<UsuarioConSaldo> ToWritable(IList<Jugador> js)
		{
			
			IList<UsuarioConSaldo> lucs = new List<UsuarioConSaldo>();
			foreach (Jugador j in js) {
				UsuarioConSaldo ucs = new UsuarioConSaldo();
				ucs.nombre = j.Nombre;
				ucs.saldo = j.Credito;

				lucs.Add(ucs);
			}

			return lucs;
		}

		public EstadoCasino EstadoActual()
		{
			VerificarClausura();
			Dinero saldo = Casino.GetInstance().getSaldoActual();
			GestionadorUsuarios g = GestionadorUsuarios.GetInstance();

			IList<Jugador> js = g.JugadoresInactivos;

			IList<UsuarioConSaldo> lucs = ToWritable(js);

			EstadoCasino ec = new EstadoCasino();
			ec.usuariosConSaldo = lucs;
			ec.saldoCasino = saldo;

			return ec;
		}

		public IList<ValorPremios> MovimientosPorJugador(string jugador)
		{
			VerificarClausura();
			GestionadorUsuarios g = GestionadorUsuarios.GetInstance();
			Jugador j = g.GetJugador(jugador, false);
			if (j == null)
				throw new Exception("El jugador no entro hoy al casino");

			IList<ValorPremios> l = ToWritable(j.Apuestas);

			return l;
		}

		private IList<ValorPremios> ToWritable(IList<Apuesta> la)
		{
			IList<ValorPremios> lvps = new List<ValorPremios>();

			foreach (Apuesta a in la)
			{
				Premio premio = a.Premio;

				MontosPremio montos = ToWritable(premio);

				ValorPremios vps = new ValorPremios();
				vps.valorApuesta = a.getValor();
				vps.montos = montos;

				lvps.Add(vps);
			}
			return lvps;
		}

		private MontosPremio ToWritable(Premio p)
		{
			MontosPremio mp = new MontosPremio();

			mp.montoFeliz = p.MontoPremioJF;
			mp.montoTodosPonen = p.MontoRetencionJTP;
			mp.premioJugada = p.MontoPremioJugada;

			return mp;
		}

		private void VerificarClausura()
		{
			if (Casino.GetInstance().EstaAbierto())
				throw new Exception("El casino se encuentra abierto");
		}

	}
}
