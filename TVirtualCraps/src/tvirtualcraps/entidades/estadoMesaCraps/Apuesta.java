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
public class Apuesta {
    
    private String apostador;
    private OpcionApuesta opcionApuesta;
    private List valorApuesta = new ArrayList();

    public Apuesta(String apostador, OpcionApuesta opcionApuesta) {
        this.apostador = apostador;
        this.opcionApuesta = opcionApuesta;
    }
    
    public void addFichaValor(FichaValor fichaValor) {
        valorApuesta.add(fichaValor);
    }

    public String getApostador() {
        return apostador;
    }

    public OpcionApuesta getOpcionApuesta() {
        return opcionApuesta;
    }

    public List getValorApuesta() {
        return valorApuesta;
    }
    
    

}
