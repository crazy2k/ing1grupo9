using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoNEW
{
    public class ReporteDados
    {
		private IList<Jugador> jugadores;
		private Jugador proxTirador;
		private bool proxTiroSalida;
		private Resultado resultadoUltimo;
		private Jugador ultimoTirador;
		private IList<Premio> premios;
		private Dictionary<Jugador,IList<ApuestaDados>> apuestas;
		private	int punto;
		private	int idMesa;
				
		public IList<Jugador> Jugadores{
			get{ return jugadores;}
			set{ jugadores = value;}
		}
		public Jugador ProxTirador{
			get{ return proxTirador;}
			set{ proxTirador = value;}
		}
		public bool ProxTiroSalida{
			get{ return proxTiroSalida;}
			set{ proxTiroSalida = value;}
		}
		public Resultado ResultadoUltimo{
			get{ return resultadoUltimo;}
			set{ resultadoUltimo = value;}
		}
		public Jugador UltimoTirador{
			get{ return ultimoTirador;}
			set{ ultimoTirador = value;}
		}
		public IList<Premio> Premios{
			get{ return premios;}
			set{ premios = value;}
		}
		public Dictionary<Jugador,IList<ApuestaDados>> Apuestas{
			get{ return apuestas;}
			set{ apuestas = value;}
		}
		public	int Punto{
			get{ return punto;}
			set{ punto = value;}
		}
		public	int IdMesa{
			get{ return idMesa;}
			set{ idMesa = value;}
		}
    }
}
