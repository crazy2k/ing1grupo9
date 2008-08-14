using System;
using System.Configuration;

namespace CasinoNEW
{
    public class GeneradorJugadasDados
    {
        private Pair proxJugada = new Pair();

		public GeneradorJugadasDados() {
			obtenerJugada();
		}

        public Pair obtenerJugada()
        {
			Pair jugada = proxJugada;
			
			TipoJugada tj = Casino.GetInstance().ObtenerTipoDeJugada();
			ResultadoDados result = getNewResultado();
			
			proxJugada = new Pair(tj, result);
            
			return jugada;
        }

        private int setValorDado(double rFloat)
        {
            if (rFloat < 1.0 / 6)
            {
                return 1;
            }
            else if (rFloat >= 1.0 / 6 && rFloat < 2.0 / 6)
            {
				return 2;
            }
            else if (rFloat >= 2.0 / 6 && rFloat < 3.0 / 6)
            {
				return 3;
            }
            else if (rFloat >= 3.0 / 6 && rFloat < 4.0 / 6)
            {
				return 4;
            }
            else if (rFloat >= 4.0 / 6 && rFloat < 5.0 / 6)
            {
				return 5;
            }
            else
            {
				return 6;
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
        public ResultadoDados getNewResultado()
        {
			Random r1 = new Random(DateTime.Now.Millisecond);
			double rFloat1 = r1.NextDouble();
			double rFloat2 = r1.NextDouble();
			int dado1 , dado2;
			dado1 = setValorDado(rFloat1);
			dado2 = setValorDado(rFloat2);
			ResultadoDados result = new ResultadoDados(dado1, dado2);
			return result;
			
        }
    }
}
