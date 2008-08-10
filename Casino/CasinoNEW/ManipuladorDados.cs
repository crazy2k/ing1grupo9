using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoNEW
{
	class ManipuladorDados : Manipulador
	{

        #region Manipulador Members

        public override void manipularResultado(Resultado res, List<Mesa> mesas)
        {
            foreach (Mesa m in mesas)
            {
                MesaDados mDados = (MesaDados)m;
                mDados.GeneradorJugadas.setResultado((ResultadoDados)res);
            }
        }

        public override void manipularJugadaTP(List<Mesa> mesas)
        {
            foreach (Mesa m in mesas)
            {
                MesaDados mDados = (MesaDados)m;
                mDados.GeneradorJugadas.setTipoJugada(TipoJugada.TodosPonen);
            }
        }

        public override void manipularJugadaFeliz(Mesa mesa)
        {
            MesaDados mesaDados = (MesaDados)mesa;
            mesaDados.GeneradorJugadas.setTipoJugada(TipoJugada.Feliz);
        }

        #endregion
    }
}
