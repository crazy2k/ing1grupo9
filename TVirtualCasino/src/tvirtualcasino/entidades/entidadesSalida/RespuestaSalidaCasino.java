/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcasino.entidades.entidadesSalida;

import tvirtualcasino.entidades.Usuario;
import tvirtualcasino.entidades.Vterm;

/**
 *
 * @author iiacobac
 */
public class RespuestaSalidaCasino {
    
    private Vterm vTerm;    
    private Usuario usuario;
    private String aceptado;
    private String descripcion;

    public RespuestaSalidaCasino(Vterm vTerm, Usuario usuario, String aceptado, String descripcion) {
        this.vTerm = vTerm;
        this.usuario = usuario;
        this.aceptado = aceptado;
        this.descripcion = descripcion;
    }

    public String getAceptado() {
        return aceptado;
    }

    public void setAceptado(String aceptado) {
        this.aceptado = aceptado;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public Usuario getUsuario() {
        return usuario;
    }

    public void setUsuario(Usuario usuario) {
        this.usuario = usuario;
    }

    public Vterm getVTerm() {
        return vTerm;
    }

    public void setVTerm(Vterm vTerm) {
        this.vTerm = vTerm;
    }
    
    
    

}
