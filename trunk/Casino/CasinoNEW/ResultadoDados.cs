using System;
using System.Configuration;

namespace CasinoNEW
{
    public class ResultadoDados: Resultado
    {
        private int Dado1;
        private int Dado2;
    
    public int sumaDados()
        {
            return Dado1+Dado2;
        }
    }
}
