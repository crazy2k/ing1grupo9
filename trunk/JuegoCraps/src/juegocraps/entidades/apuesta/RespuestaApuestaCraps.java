/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package juegocraps.entidades.apuesta;

import juegocraps.entidades.Mesa;
import juegocraps.entidades.Usuario;
import juegocraps.entidades.Vterm;

/**
 *
 * @author Yakko
 */
public class RespuestaApuestaCraps {
    
    private Vterm vTerm;    
    private Usuario usuario;    
    private Mesa mesa;
    private String aceptado;

    public RespuestaApuestaCraps(Vterm vTerm, Usuario usuario, Mesa mesa, String aceptado) {
        this.vTerm = vTerm;
        this.usuario = usuario;
        this.mesa = mesa;
        this.aceptado = aceptado;
    }

    public String getAceptado() {
        return aceptado;
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
