using System;
using System.Configuration;
using Ficha = System.Decimal;
using Cantidad = System.Int32;
using Definida = System.Boolean;
using Dinero = System.Decimal;

namespace CasinoNEW
{
    public class ApuestaPassNoPass: ApuestaDados
    {
        private bool aFavor;
        private int punto;
        bool tiroDeSalida = true;

		public bool AFavor
		{
			get { return aFavor; }
		}

		public ApuestaPassNoPass(bool favor, Ficha ficha, Cantidad cant){
			fichas = new System.Collections.Generic.Dictionary<Dinero,int>();
			fichas.Add(ficha, cant);
			valor = ficha*cant;
			aFavor = favor;		
		}
		
        public override Pair evaluar(ResultadoDados res)
        {
            Dinero premioAPagar;
            if (tiroDeSalida) 
            {
                if (res.sumaDados() == 7 || res.sumaDados() == 11) 
                { 
                    premioAPagar = aFavor ? valor*2 : 0;
//                    tiroDeSalida = false;
                    this.premio.MontoPremioJugada = premioAPagar;
                    return new Pair(true,premioAPagar); 
                }
                else if (res.sumaDados() == 2 || res.sumaDados() == 3) 
                { 
                    premioAPagar = aFavor ? 0 : valor*2;
  //                  tiroDeSalida = false;
                    this.premio.MontoPremioJugada = premioAPagar;
                    return new Pair(true,premioAPagar); 
                }
                else if (res.sumaDados() == 12) 
                { 
                    premioAPagar = aFavor ? 0 : valor;
   //                 tiroDeSalida = false;
                    this.premio.MontoPremioJugada = premioAPagar;
                    return new Pair(true,premioAPagar); 
                } 
                else 
                {
                    punto = res.sumaDados();
                    tiroDeSalida = false;
                    this.premio.MontoPremioJugada = 0;
					premioAPagar = 0;
					return new Pair(false, premioAPagar); 
                } 
            }
            else 
            {
                if (res.sumaDados() == 7) 
                { 
                    premioAPagar = aFavor ? 0 : valor*2;
                    this.premio.MontoPremioJugada = premioAPagar;
					//Agrego esta linea:
					tiroDeSalida = true;
                    return new Pair(true,premioAPagar); 
                }
                else if (res.sumaDados() == punto) 
                { 
                    premioAPagar = aFavor ? valor*2 : 0;
                    this.premio.MontoPremioJugada = premioAPagar;
					//Agrego esta linea:
					tiroDeSalida = true;
                    return new Pair(true, premioAPagar); 
                } 
                else 
                {
                    this.premio.MontoPremioJugada = 0;
					premioAPagar = 0;
                    return new Pair(false,premioAPagar); 
                }
            }
        }
    }
}
