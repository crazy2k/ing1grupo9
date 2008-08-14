using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoNEW
{
	class ManipuladorDados : Manipulador
	{

		public ManipuladorDados(string nombre) : base(nombre) { }

        #region Manipulador Members

        public override void manipularResultado(Resultado res, IList<Mesa> mesas)
        {
            foreach (Mesa m in mesas)
            {
                MesaDados mDados = (MesaDados)m;
                mDados.GeneradorJugadas.setResultado((ResultadoDados)res);
            }
        }

        public override void manipularJugadaTP(IList<Mesa> mesas)
        {
            foreach (Mesa m in mesas)
            {
                MesaDados mDados = (MesaDados)m;
                mDados.GeneradorJugadas.setTipoJugada(TipoJugada.TodosPonen);
            }
        }

		public override void manipularJugadaNormal(IList<Mesa> mesas)
        {
            foreach (Mesa m in mesas)
            {
                MesaDados mDados = (MesaDados)m;
                mDados.GeneradorJugadas.setTipoJugada(TipoJugada.Normal);
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
