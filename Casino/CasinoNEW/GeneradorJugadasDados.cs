using System;
using System.Configuration;

namespace CasinoNEW
{
    public class GeneradorJugadasDados
    {
        private Pair proxJugada;

        public Pair obtenerJugada()
        {
			Pair jugada = proxJugada;
			setTipoJugada(Casino.GetInstance().ObtenerTipoDeJugada());
            Random r1 = new Random(DateTime.Now.Millisecond);
            Random r2 = new Random(DateTime.Now.Millisecond);
            double rFloat1 = r1.NextDouble();
            double rFloat2 = r2.NextDouble();
            int dado1=0, dado2=0;
            setValorDado(dado1, rFloat1);
            setValorDado(dado2, rFloat2);
            setResultado(new ResultadoDados(dado1, dado2));
			return jugada;
        }

        private void setValorDado(int dado, double rFloat)
        {
            if (rFloat < 1 / 6)
            {
                dado = 1;
            }
            else if (rFloat >= 1 / 6 && rFloat < 2 / 6)
            {
                dado = 2;
            }
            else if (rFloat >= 2 / 6 && rFloat < 3 / 6)
            {
                dado = 3;
            }
            else if (rFloat >= 3 / 6 && rFloat < 4 / 6)
            {
                dado = 4;
            }
            else if (rFloat >= 4 / 6 && rFloat < 5 / 6)
            {
                dado = 5;
            }
            else
            {
                dado = 6;
            }
        }
        public void setTipoJugada(TipoJugada t)
        {
            proxJugada.setFirst(t);
        }
        public void setResultado(ResultadoDados r)
        {
            proxJugada.setSecond(r);
        }
    }
}
