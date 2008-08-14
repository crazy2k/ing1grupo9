/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcraps.entidades.entrada;

import tvirtualcraps.entidades.Mesa;
import tvirtualcraps.entidades.Usuario;
import tvirtualcraps.entidades.Vterm;

/**
 *
 * @author Yakko
 */
public class RespuestaEntradaCraps {
    
    private Vterm vTerm;    
    private Usuario usuario;    
    private Mesa mesa;
    private String aceptado;
    private String descripcion;

    public RespuestaEntradaCraps(Vterm vTerm, Usuario usuario, Mesa mesa, String aceptado, String descripcion) {
        this.vTerm = vTerm;
        this.usuario = usuario;
        this.mesa = mesa;
        this.aceptado = aceptado;
        this.descripcion = descripcion;
    }
        
    public String getAceptado() {
        return aceptado;
    }

    public String getDescripcion() {
        return descripcion;
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
