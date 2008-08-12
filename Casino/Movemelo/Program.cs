using System;
using System.Collections.Generic;
using System.Text;

namespace Movemelo
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Organizando Archivos...");
			Organizador o = new Organizador();
			o.Organizar();
			
		}
	}
}
