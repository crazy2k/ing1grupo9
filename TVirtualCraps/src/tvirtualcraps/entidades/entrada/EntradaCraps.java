package tvirtualcraps.entidades.entrada;

import tvirtualcraps.entidades.*;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Yakko
 */
public class EntradaCraps {
    
    private Vterm vTerm;    
    private Usuario usuario;    
    private Mesa mesa;

    public EntradaCraps(Vterm vTerm, Usuario usuario, Mesa mesa) {
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
