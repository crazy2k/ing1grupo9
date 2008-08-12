// Poller.cs created with MonoDevelop
// User: pablo at 13:37 29/07/2008
//

using System;
using System.Collections.Generic;

namespace CasinoNEW
{
	
	public class Poller
	{
		private IList<Lector> lectores = new List<Lector>();
		
		public Poller()
		{
			lectores.Add(new LectorCasino());
			lectores.Add(new LectorDados());
			lectores.Add(new LectorAdministracion());
			lectores.Add(new LectorManipulacion());
//TODO: Agregar al poller los lectores			
		}

		public void poll() {
			while (true) {
				foreach(Lector l in lectores)
					l.Leer();
//TODO: Ver si se le pone que espere entre lectura y lectura al poller
			}
		}
		
	}
}
