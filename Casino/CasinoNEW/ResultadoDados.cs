using System;
using System.Configuration;

namespace CasinoNEW
{
    public class ResultadoDados: Resultado
    {
        private int dado1;
        private int dado2;
		public int Dado1
		{
			get { return dado1; }
		}
		public int Dado2
		{
			get { return dado2; }
		}

    public ResultadoDados(int d1, int d2)
        {
            dado1 = d1;
            dado2 = d2;
        }
    public int sumaDados()
        {
            return dado1+dado2;
        }
    }
}
