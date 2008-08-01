using System;
using System.Configuration;

namespace CasinoNEW
{
    public class JuegoDados: Juego
    {
		private int cantMesas = 0;
		
		public override Mesa CrearMesa()
		{
			cantMesas++;
			Mesa nuevaMesa = new MesaDados(cantMesas);
			mesas.add(nuevaMesa);
			return nuevaMesa;
		}
		
		public override void Reset()
		{
			mesas.Clear();
			cantMesas = 0;
		}
    }
}
