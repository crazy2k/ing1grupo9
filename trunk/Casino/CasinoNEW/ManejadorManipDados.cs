// ManejadorManipDados.cs created with MonoDevelop
// User: tas at 13:56 08/08/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.Generic;

namespace CasinoNEW
{
	
	
	public class ManejadorManipDados
	{
		
		public ManejadorManipDados() {}
		
		public static void ManipularJF(MesaDados m){
			m.GeneradorJugadas.setTipoJugada(TipoJugada.Feliz);
		}
		public static void ManipularJTP(List<MesaDados> mesas){
			foreach(MesaDados m in mesas){
				m.GeneradorJugadas.setTipoJugada(TipoJugada.TodosPonen);
			}
		}
		public static void ManipularResultado(int dado1, int dado2){
			ResultadoDados r = new ResultadoDados(dado1, dado2);
			List<Mesa> mesas = JuegoDados.GetInstance().getMesas();
			List<MesaDados> mesasD = new List<MesaDados>();
			foreach (Mesa m in mesas){
				MesaDados md = (MesaDados)m;
				mesasD.Add(md);
			}
			foreach(MesaDados m in mesasD){
				m.GeneradorJugadas.setResultado(r);
			}
		}
	}
}
