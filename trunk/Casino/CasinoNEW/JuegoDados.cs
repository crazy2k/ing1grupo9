using System;
using System.Configuration;
using Dinero = System.Decimal;

namespace CasinoNEW
{
    public class JuegoDados: Juego
    {
		private int cantMesas = 0;
		
		private static JuegoDados instance = null;
		
		private JuegoDados() {
			Nombre = "dados";
		}
		
		public static JuegoDados GetInstance() {
			if (instance == null)
				instance = new JuegoDados();
			return instance;
		}
		
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
			cantMesas--;
			foreach(Mesa m in mesas){
				if ( m.Id == mesa)
					mesas.Remove(m);
			}
		}

    }
}
