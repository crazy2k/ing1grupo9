/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcasino.entidades.entidadesEstadoCasino.Juegos;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author iiacobac
 */
public class Tragamonedas {
    
    private String pozoProgresivo;
    private List mesasTragamonedas = new ArrayList();

    public Tragamonedas(String pozoProgresivo) {
        this.pozoProgresivo = pozoProgresivo;        
    }

    public String getPozoProgresivo() {
        return pozoProgresivo;
    }

}
