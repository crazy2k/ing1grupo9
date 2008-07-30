// Casino.cs created with MonoDevelop
// User: pablo at 2:37 PM 7/30/2008
//

using System;

namespace CasinoNEW
{
	
	
	public class Casino
	{
		
		private static Casino instance = null;
		
		private bool estaAbierto = false;
		
		private Casino()
		{
		}
		
		public static Casino GetInstance() {
			if (instance == null)
				instance = new Casino();
			return instance;
		}
		
		public bool EstaAbierto() {
			return estaAbierto;
		}
	}
}
