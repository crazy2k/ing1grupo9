using System;
using System.Configuration;
using Ficha = System.Decimal;
using Cantidad = System.Int32;
using Definida = System.Boolean;
using Dinero = System.Decimal;

namespace CasinoNEW
{
    public class ApuestaDeCampo : ApuestaDados
    {
		ApuestaDeCampo(Ficha ficha, Cantidad cant){
			fichas = new System.Collections.Generic.Dictionary<decimal,int>();
			fichas.Add(ficha, cant);
			valor = ficha*cant;
		}
		
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
