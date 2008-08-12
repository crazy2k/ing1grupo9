// Main.cs created with MonoDevelop
// User: tas at 11:54 12/08/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//
using System;

namespace Organizador
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Organizando Archivos...");
			Organizador o = new Organizador();
			o.Organizar();
			
		}
	}
}