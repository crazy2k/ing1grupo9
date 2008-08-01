using System;
using System.Configuration;
using Dinero = System.Decimal;

namespace CasinoNEW
{
    public class JuegoDados: Juego
    {
		private int cantMesas = 0;
		
		public override Mesa CrearMesa()
		{
			cantMesas++;
			Mesa nuevaMesa = new MesaDados(cantMesas);
			mesas.Add(nuevaMesa);
			return nuevaMesa;
		}
		
		public override void Reset()
		{
			mesas.Clear();
			cantMesas = 0;
		}
		
		public void CerrarMesa(int mesa)
		{
			cantMesas = cantMesas--;
			foreach(Mesa m in mesas){
				if ( m.Id == mesa)
					mesas.Remove(m);
			}
		}
    }
}
