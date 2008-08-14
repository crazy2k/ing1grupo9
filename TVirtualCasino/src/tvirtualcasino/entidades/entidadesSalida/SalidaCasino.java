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
public class SalidaCasino {
    
    private Vterm vTerm;    
    private Usuario usuario;

    public SalidaCasino(Vterm vTerm, Usuario usuario) {
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
