// Main.cs created with MonoDevelop
// User: pablo at 11:01 29/07/2008
//
using System;

namespace CasinoNEW
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Poller p = new Poller();
			p.poll();
			Console.WriteLine("Se rompe todo");
		}
	}
}