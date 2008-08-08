// Casino.cs created with MonoDevelop
// User: pablo at 2:37 PM 7/30/2008
//

using System;
using System.IO;
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

using Ficha = System.Decimal; //Asi se hacen los renombres de tipo. 
using Dinero = System.Decimal;

namespace CasinoNEW
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
		
		
		public float PorcJugadaTodosPonen{
			get{ return porcJugadaTodosPonen; }
			set{ porcJugadaTodosPonen = value; }
		}
		
		private IList<Juego> juegos = new List<Juego>();

        #endregion

        #region getters

		public IList<Juego> Juegos {
			get { return juegos; }
		}
		
		public IDictionary<string, Dinero> Pozos {
			get {
				IDictionary<string, Dinero> d =
					new Dictionary<string, Dinero>();
				// Por ahora está sólo el pozo feliz, pero en el futuro
				// podrían haber varios.
				d.Add("pozoFeliz", this.getMontoPozoFeliz());
				
				return d;
			}
		}
		
		public List<Ficha> GetFichas() {
			return fichas;
		}
        
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

        private Casino() {
			juegos.Add(JuegoDados.GetInstance());
		}
		
        public static Casino GetInstance()
        {
             if (instance == null) 
             {
                lock (syncRoot) 
                {
					if (instance == null) {
						instance = new Casino();
						//Le pongo el juego de Dados, sinó nunca se crea.
						instance.Juegos.Add(JuegoDados.GetInstance());
						//De haber Tragamonedas habría que ponerlo acá tb.
					}
                }
             }
             return instance;
        }
        public TipoJugada ObtenerTipoDeJugada()
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

		// TODO: 
		// - Lectura de la configuración del casino
		// desde un archivo en el servidor. (Falta implementar
		// el Configurar())
		// - Resetear al gestionador y a los juegos. (HECHO)
        public void Abrir()
        {
            if (!estaAbierto)
            {
				foreach (Juego j in juegos)
					j.Reset();

				GestionadorUsuarios.GetInstance().Reset();

				Configurar();

                estaAbierto = true;
            }
            else
            {
                throw new Exception("El casino ya estaba abierto.");
            }
        }
        public void Cerrar()
        {
            if (estaAbierto)
            {
                GestionadorUsuarios gest = GestionadorUsuarios.GetInstance();
                IList<Jugador> jug = gest.JugadoresActivos;
                if (jug.Count == 0)
                {
                    estaAbierto = false;
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
	//		using (StreamReader sr = new StreamReader( Configuracion.ARCHIVO_CONFIG )) {
			StreamReader sr = new StreamReader( Configuracion.ARCHIVO_CONFIG );
			// Lista de Clientes
			string linea = ProximaLinea(sr);
			Configuracion.ARCHIVO_USUARIOS = linea;
			//Fichas
			linea = ProximaLinea(sr);
			int cantidadFichas = Convert.ToInt32(linea);
			fichas = new List<Ficha>();
			for (int i = 0 ; i < cantidadFichas; i++){
				linea = ProximaLinea(sr);
				Ficha f = Convert.ToDecimal(linea);
				fichas.Add(f);
			}
			//Probabilidades de aparición de Jugada Feliz
			linea = ProximaLinea(sr);
			double probInt = Convert.ToDouble(linea);
			probJugadaFeliz = ( (float)probInt )/100;
			//Probabilidades de aparición de Jugada TodosPonen
			linea = ProximaLinea(sr);
			probInt = Convert.ToDouble(linea);
			probJugadaTodosPonen = ( (float)probInt )/100;
			//Porcentaje a descontar de los premios por jugada TodosPonen
			linea = ProximaLinea(sr);
			double procInt = Convert.ToDouble(linea);
			porcJugadaTodosPonen = ( (float)procInt )/100;
        }
		
		private string ProximaLinea(StreamReader sr){
			string linea = sr.ReadLine();
			while (!(linea.StartsWith("#")) ) {
				linea = sr.ReadLine();
			}
			return linea;
		}

        #endregion
    }
}

