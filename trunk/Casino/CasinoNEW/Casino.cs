// Casino.cs created with MonoDevelop
// User: pablo at 2:37 PM 7/30/2008
//

using System;
using System.Data;
using System.Configuration;
/*using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
*/
using System.Collections.Generic;

using Ficha = System.Int32; //Asi se hacen los renombres de tipo. 
using Dinero = System.Decimal;

namespace Casino
{
    //Microsoft garantiza que esta implementacion de singleton es thread-safe.
    //Para mas info ver http://msdn.microsoft.com/en-us/library/ms998558.aspx

    public sealed class Casino
    {
        #region variables

        private static volatile Casino instance;
        private static object syncRoot = new Object();
        private Dinero montoPozoFeliz;
        private bool estaAbierto; //La inicializacion por default lo deja en false (cerrado)
        private float probJugadaTodosPonen;
        private float probJugadaFeliz;
        private Dinero saldoActual;
        private List<Ficha> fichas;
        private float porcJugadaTodosPonen;

        #endregion

        #region getters
        
        public Dinero getMontoPozoFeliz()
        {
            return montoPozoFeliz;
        }

        public float getProbJugadaTodosPonen()
        {
            return probJugadaTodosPonen;
        }

        public float getProbJugadaFeliz()
        {
            return probJugadaFeliz;
        }

        public Dinero getSaldoActual()
        {
            return saldoActual;
        }


        #endregion

        #region funciones

        private Casino() {}
        public static Casino getInstance()
        {
             if (instance == null) 
             {
                lock (syncRoot) 
                {
                   if (instance == null) 
                      instance = new Casino();
                }
             }
             return instance;
        }
        public TipoJugada obtenerTipoDeJugada()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            double rFloat = r.NextDouble();
            TipoJugada tipoJug;
            if (rFloat < probJugadaFeliz)
            {
                tipoJug = TipoJugada.Feliz;
            }
            else if (rFloat >= probJugadaFeliz & rFloat < probJugadaFeliz + probJugadaTodosPonen)
            {
                tipoJug = TipoJugada.TodosPonen;
            }
            else
            {
                tipoJug = TipoJugada.Normal;
            }
            return tipoJug;
        }
        public void Pagar(Dinero costo, Jugador jug)
        {
            saldoActual -= costo;
            jug.cobrar(costo);
        }
        public void Cobrar(Dinero ganancia, Jugador jug)
        {
            saldoActual += ganancia;
            jug.pagar(ganancia);
        }

        public void Abrir()
        {
            if (!abierto)
            {
                abierto = true;
            }
            else
            {
                throw new Exception("El casino ya estaba abierto.");
            }
        }
        public void Cerrar()
        {
            if (abierto)
            {
                GestionadorUsuarios gest = GestionadorUsuarios.getInstance();
                List<Jugador> jug = gest.getJugadoresActivos();
                if (jug.Count == 0)
                {
                    abierto = false;
                }
                else
                {
                    throw new Exception("Hay jugadores activos en el casino.");
                }
            }
            else
            {
                throw new Exception("El casino ya estaba cerrado.");
            }
        }
		
		public bool EstaAbierto() {
			return estaAbierto;
		}
		
		public Dinero TomarPozoFeliz(){
			Dinero pozo = montoPozoFeliz;
			montoPozoFeliz = 0;
			return pozo;
		}
		
        public void Configurar()
        {
        }

        #endregion
    }
}

