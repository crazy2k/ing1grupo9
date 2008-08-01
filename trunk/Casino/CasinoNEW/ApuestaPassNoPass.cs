using System;
using System.Configuration;

namespace CasinoNEW
{
    public class ApuestaPassNoPass: ApuestaDados
    {
        private bool aFavor;
        private int punto;
        bool tiroDeSalida = true;

        ApuestaPassNoPass() {}
        public override Pair evaluar(ResultadoDados res)
        {
            decimal premio;
            if (tiroDeSalida) 
            {
                if (res.sumaDados() == 7 || res.sumaDados() == 11) 
                { 
                    premio = aFavor ? valor*2 : 0;
                    tiroDeSalida = false; 
                    return new Pair(true,premio); 
                }
                else if (res.sumaDados() == 2 || res.sumaDados() == 3) 
                { 
                    premio = aFavor ? 0 : valor*2;
                    tiroDeSalida = false; 
                    return new Pair(true,premio); 
                }
                else if (res.sumaDados() == 12) 
                { 
                    premio = aFavor ? 0 : valor;
                    tiroDeSalida = false; 
                    return new Pair(true,premio); 
                } 
                else 
                {
                    punto = res.sumaDados();
                    tiroDeSalida = false; 
                    return new Pair(false,-1); 
                } 
            }
            else 
            {
                if (res.sumaDados() == 7) 
                { 
                    premio = aFavor ? 0 : valor*2;
                    return new Pair(true,premio); 
                }
                else if (res.sumaDados() == punto) 
                { 
                    premio = aFavor ? valor*2 : 0;
                    return new Pair(true, premio); 
                } 
                else 
                { 
                    return new Pair(false,-1); 
                }
            }
        }
    }
}
