using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoNEW
{
    public class ReporteDados
    {
		private List<Jugador> jugadores;
		private Jugador proxTirador;
		private bool proxTiroSalida;
		private Resultado resultadoUltimo;
		private Jugador ultimoTirador;
		private List<Premio> premios;
		private List<Apuesta> apuestas;
		private	int punto;
		private	int idMesa;
				
		public List<Jugador> Jugadores{
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
		public List<Premio> Premios{
			get{ return premios;}
			set{ premios = value;}
		}
		public List<Apuesta> Apuestas{
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
