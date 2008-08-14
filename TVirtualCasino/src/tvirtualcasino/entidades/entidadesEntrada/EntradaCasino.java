/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcasino.entidades.entidadesEntrada;

import tvirtualcasino.entidades.Vterm;
import tvirtualcasino.entidades.Usuario;

/**
 *
 * @author Yakko
 */
public class EntradaCasino {
    
    private Vterm vTerm;    
    private Usuario usuario;    
    private String modoAcceso;

    public EntradaCasino(Vterm vTerm, Usuario usuario, String modoAcceso) {
        this.vTerm = vTerm;
        this.usuario = usuario;
        this.modoAcceso = modoAcceso;
    }

    public String getModoAcceso() {
        return modoAcceso;
    }

    public Usuario getUsuario() {
        return usuario;
    }

    public Vterm getVTerm() {
        return vTerm;
    }    
    
}
