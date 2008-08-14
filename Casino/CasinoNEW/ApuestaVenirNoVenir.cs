using System;
using System.Configuration;
using Ficha = System.Decimal;
using Cantidad = System.Int32;
using Definida = System.Boolean;
using Dinero = System.Decimal;

namespace CasinoNEW
{
    public class ApuestaVenirNoVenir: ApuestaDados
    {
        private bool aFavor;
        private int puntajeVenir;
        private bool tiroDeApuesta = true;

		public bool AFavor
		{
			get { return aFavor; }
		}

		public int Puntaje
		{
			get { return puntajeVenir; }
		}

		public ApuestaVenirNoVenir(bool favor, Ficha ficha, Cantidad cant){
			fichas = new System.Collections.Generic.Dictionary<Dinero,int>();
			fichas.Add(ficha, cant);
			valor = ficha*cant;
			aFavor = favor;
		}

        public override Pair evaluar(ResultadoDados res)
        {
            Dinero premio;
            if (tiroDeApuesta)
            {
                if (res.sumaDados() == 7 || res.sumaDados() == 11)
                {
                    premio = aFavor ? valor * 2 : 0;
                    tiroDeApuesta = false;
                    this.premio.MontoPremioJugada = premio;
                    return new Pair(true, premio);
                }
                else if (res.sumaDados() == 2 || res.sumaDados() == 3)
                {
                    premio = aFavor ? 0 : valor * 2;
                    tiroDeApuesta = false;
                    this.premio.MontoPremioJugada = premio;
                    return new Pair(true, premio);
                }
                else if (res.sumaDados() == 12)
                {
                    premio = aFavor ? 0 : valor;
                    tiroDeApuesta = false;
                    this.premio.MontoPremioJugada = premio;
                    return new Pair(true, premio);
                }
                else
                {
                    puntajeVenir = res.sumaDados();
                    tiroDeApuesta = false;
                    this.premio.MontoPremioJugada = 0;
					premio = 0;
                    return new Pair(false, premio);
                }
            }
            else
            {
                if (res.sumaDados() == 7)
                {
                    premio = aFavor ? 0 : valor * 2;
                    this.premio.MontoPremioJugada = premio;
                    return new Pair(true, premio);
                }
                else if (res.sumaDados() == puntajeVenir)
                {
                    premio = aFavor ? valor * 2 : 0;
                    this.premio.MontoPremioJugada = premio;
                    return new Pair(true, premio);
                }
                else
                {
                    this.premio.MontoPremioJugada = 0;
					premio = 0;
                    return new Pair(false, premio);
                }
            }
        }
    }
}
