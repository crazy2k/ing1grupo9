using System;
using System.Configuration;

namespace CasinoNEW
{
    public class ResultadoDados: Resultado
    {
        private int Dado1;
        private int Dado2;

    public ResultadoDados(int d1, int d2)
        {
            Dado1 = d1;
            Dado2 = d2;
        }
    public int sumaDados()
        {
            return Dado1+Dado2;
        }
    }
}
