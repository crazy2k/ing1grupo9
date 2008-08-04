using System;
using System.Configuration;

namespace CasinoNEW
{
    public class ApuestaDeCampo : ApuestaDados
    {
        public override Pair evaluar(ResultadoDados res)
        {
            decimal premio;
            if (res.sumaDados() == 3 || res.sumaDados() == 4 || res.sumaDados() == 9 || 
                res.sumaDados() == 10 || res.sumaDados() == 11) 
            { 
                premio = valor*2;
            }
            else if (res.sumaDados() == 2 || res.sumaDados() == 12) 
            { 
                premio = valor*3;
            } 
            else 
            { 
                premio = 0; 
            }
            this.premio.MontoPremioJugada = premio;
            return new Pair(true, premio);
        }
    }
}
