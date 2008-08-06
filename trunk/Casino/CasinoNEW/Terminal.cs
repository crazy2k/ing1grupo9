// Terminal.cs created with MonoDevelop
// User: tas at 12:04 06/08/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace CasinoNEW
{
	
	
	public class Terminal
	{
		private int id;
		public int Id{
			get{ return id;}
	//		set{ id = value;}
		}
		private Jugador observador;
		public Jugador Observador{
			get { return observador;}
	//		set {observador = value;}
		}
		public Terminal(int idTerminal, Jugador obs)
		{
			id = idTerminal;
			observador = obs;
		}
	}
}
