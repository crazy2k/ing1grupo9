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
		}

		public void poll() {
			while (true) {
				foreach(Lector l in lectores) {
					l.Leer();
				}
			}
		}
		
	}
}
