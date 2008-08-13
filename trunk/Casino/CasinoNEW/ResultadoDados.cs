using System;
using System.Configuration;

namespace CasinoNEW
{
    public class ResultadoDados: Resultado
    {
        private int dado1 = 0;
        private int dado2 = 0;
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
		public override string ToString() {
			return sumaDados().ToString();		
		}
    public int sumaDados()
        {
            return dado1+dado2;
        }
    }
}
