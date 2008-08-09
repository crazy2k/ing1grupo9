using System;
using System.Configuration;
using Ficha = System.Decimal;
using Cantidad = System.Int32;
using Definida = System.Boolean;
using Dinero = System.Decimal;

namespace CasinoNEW
{
    public class ApuestaGanarEnContra: ApuestaDados
    {
        private bool aFavor;
        private int puntaje;

		public bool AFavor
		{
			get { return aFavor; }
		}

		public int Puntaje
		{
			get { return puntaje; }
		}

        public ApuestaGanarEnContra(bool afavor, int p, Ficha ficha, Cantidad cant)
        {
			fichas = new System.Collections.Generic.Dictionary<decimal,int>();
			fichas.Add(ficha, cant);
			valor = ficha*cant;
            aFavor = afavor;
            puntaje = p;
        }
        public override Pair evaluar(ResultadoDados res)
        {
            decimal premio=0;
            if (res.sumaDados()==7) 
            { 
                if (aFavor) 
                { 
                    premio = 0;
                    this.premio.MontoPremioJugada = premio;
                    return new Pair(true,premio); 
                } 
                else 
                { 
                    switch (res.sumaDados())
                    {
                        case 4: premio = valor * 5 / 11; 
                                break;
                        case 5: premio = valor*5/8;
                                break;
                        case 6: premio = valor*4/5;
                                break;
                        case 8: premio = valor*4/5;
                                break;
                        case 9: premio = valor*5/8;
                                break;
                        case 10: premio = valor*5/11;
                                break;
                    }
                    this.premio.MontoPremioJugada = premio;
                    return new Pair(true,premio); 
                } 
            } 
            else if (res.sumaDados()==puntaje) 
            { 
                if (!aFavor) 
                { 
                    premio = 0;
                    this.premio.MontoPremioJugada = premio;
                    return new Pair(true,premio);
                } 
                else 
                {
                    switch (res.sumaDados())
                    {
                        case 4: premio = valor * 9 / 5;
                                break;
                        case 5: premio = valor * 7 / 5;
                                break;
                        case 6: premio = valor * 7 / 6;
                                break;
                        case 8: premio = valor * 7 / 6;
                                break;
                        case 9: premio = valor * 7 / 5;
                                break;
                        case 10: premio = valor * 9 / 5;
                                break;
                    }
                    this.premio.MontoPremioJugada = premio;
                    return new Pair(true,premio);
                }
            } 
            else
            {
                this.premio.MontoPremioJugada = -1;
                return new Pair(false,-1); 
            }
        }
    }
}
