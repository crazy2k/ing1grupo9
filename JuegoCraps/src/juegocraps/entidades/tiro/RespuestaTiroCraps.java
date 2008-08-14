/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package juegocraps.entidades.tiro;

import juegocraps.entidades.Mesa;
import juegocraps.entidades.Resultado;
import juegocraps.entidades.Usuario;
import juegocraps.entidades.Vterm;

/**
 *
 * @author Yakko
 */
public class RespuestaTiroCraps {
    
    private Vterm vTerm;    
    private Usuario usuario;    
    private Mesa mesa;
    private String aceptado;
    private String tipoJugada;
    private Resultado resultado;

    public RespuestaTiroCraps(Vterm vTerm, Usuario usuario, Mesa mesa, String aceptado, String tipoJugada, Resultado resultado) {
        this.vTerm = vTerm;
        this.usuario = usuario;
        this.mesa = mesa;
        this.aceptado = aceptado;
        this.tipoJugada = tipoJugada;
        this.resultado = resultado;
    }

    public Mesa getMesa() {
        return mesa;
    }

    public String getAceptado() {
        return aceptado;
    }

    public Resultado getResultado() {
        return resultado;
    }

    public String getTipoJugada() {
        return tipoJugada;
    }

    public Usuario getUsuario() {
        return usuario;
    }

    public Vterm getVTerm() {
        return vTerm;
    }

}
