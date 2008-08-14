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
public class Craps {
    
    private List mesasCraps = new ArrayList();

    public void addMesaCraps(MesaCraps mesaCraps) {
        mesasCraps.add(mesaCraps);
    }

    public List getMesasCraps() {
        return mesasCraps;
    }

}
