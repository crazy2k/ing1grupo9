/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcraps.entidades.estadoMesaCraps;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Yakko
 */
public class UltimoTiro {
    
    private String tirador;
    private String resultado;
    private List premios = new ArrayList();

    public UltimoTiro(String tirador, String resultado) {
        this.tirador = tirador;
        this.resultado = resultado;
    }

    public String getResultado() {
        return resultado;
    }

    public String getTirador() {
        return tirador;
    }
    
     public void addPremio(Premio premio) {
        premios.add(premio);
    }

    public List getPremios() {
        return premios;
    }

}
