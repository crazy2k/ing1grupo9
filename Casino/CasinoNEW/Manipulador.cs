// Manipulador.cs created with MonoDevelop
// User: pablo at 4:07 PM 7/30/2008
//

using System;
using System.Collections.Generic;

namespace CasinoNEW
{
	interface Manipulador
	{
        void manipularResultado(Resultado res, List<Mesa> mesas);
        void manipularJugadaTP(List<Mesa> mesas);
        void manipularJugadaFeliz(Mesa mesa);
	}
}
