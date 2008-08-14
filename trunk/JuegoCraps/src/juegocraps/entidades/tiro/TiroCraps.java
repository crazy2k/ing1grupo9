/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package juegocraps.entidades.tiro;

import juegocraps.entidades.Mesa;
import juegocraps.entidades.Usuario;
import juegocraps.entidades.Vterm;

/**
 *
 * @author Yakko
 */
public class TiroCraps {
    
    private Vterm vTerm;    
    private Usuario usuario;    
    private Mesa mesa;

    public TiroCraps(Vterm vTerm, Usuario usuario, Mesa mesa) {
        this.vTerm = vTerm;
        this.usuario = usuario;
        this.mesa = mesa;
    }

    public Mesa getMesa() {
        return mesa;
    }

    public Usuario getUsuario() {
        return usuario;
    }

    public Vterm getVTerm() {
        return vTerm;
    }

}
