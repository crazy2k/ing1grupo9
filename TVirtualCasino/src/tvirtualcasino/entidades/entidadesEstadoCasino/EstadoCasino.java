/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcasino.entidades.entidadesEstadoCasino;

import tvirtualcasino.entidades.Usuario;
import tvirtualcasino.entidades.Vterm;

/**
 *
 * @author Yakko
 */
public class EstadoCasino {
    
    private Vterm vTerm;    
    private Usuario usuario;

    public EstadoCasino(Vterm vTerm, Usuario usuario) {
        this.vTerm = vTerm;
        this.usuario = usuario;
    }

    public Usuario getUsuario() {
        return usuario;
    }

    public Vterm getVTerm() {
        return vTerm;
    }
    
    

}
