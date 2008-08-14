/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcasino.entidades.entidadesEstadoCasino;

import tvirtualcasino.entidades.entidadesEstadoCasino.Juegos.Craps;
import tvirtualcasino.entidades.entidadesEstadoCasino.Juegos.Tragamonedas;

/**
 *
 * @author iiacobac
 */
public class Juego {
    
    private Tragamonedas tragamonedas;
    private Craps craps;    

    public Juego(Tragamonedas tragamonedas, Craps craps) {
        this.craps = craps;
        this.tragamonedas = tragamonedas;
    }

    public Craps getCraps() {
        return craps;
    }

    public Tragamonedas getTragamonedas() {
        return tragamonedas;
    }

}
