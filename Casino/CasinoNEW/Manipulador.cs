// Manipulador.cs created with MonoDevelop
// User: pablo at 4:07 PM 7/30/2008
//

using System;
using System.Collections.Generic;

namespace CasinoNEW
{
	public abstract class Manipulador : Usuario
	{
		public Manipulador(string nombre) : base(nombre) { }
        public abstract void manipularResultado(Resultado res, IList<Mesa> mesas);
        public abstract void manipularJugadaTP(IList<Mesa> mesas);
		public abstract void manipularJugadaFeliz(Mesa mesa);
		public abstract void manipularJugadaNormal(IList<Mesa> mesas);
	}
}
