/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package juegocraps.entidades.apuesta;

import java.util.ArrayList;
import java.util.List;
import juegocraps.entidades.Mesa;
import juegocraps.entidades.Usuario;
import juegocraps.entidades.Vterm;

/**
 *
 * @author Yakko
 */
public class ApuestaTiroCraps {
    
    private Vterm vTerm;    
    private Usuario usuario;    
    private Mesa mesa;
    private OpcionApuesta opcionApuesta;
    private List valorApuesta = new ArrayList();

    public ApuestaTiroCraps(Vterm vTerm, Usuario usuario, Mesa mesa, OpcionApuesta opcionApuesta) {
        this.vTerm = vTerm;
        this.usuario = usuario;
        this.mesa = mesa;
        this.opcionApuesta = opcionApuesta;      
    }
    
    public void addValorApuesta(FichaValor ficha) {
        this.valorApuesta.add(ficha);        
    }
    
    public void setValorApuesta(List fichas) {
        this.valorApuesta = fichas;
    }

    public List getValorApuesta() {
        return valorApuesta;
    }

    public Mesa getMesa() {
        return mesa;
    }

    public void setMesa(Mesa mesa) {
        this.mesa = mesa;
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

    public OpcionApuesta getOpcionApuesta() {
        return opcionApuesta;
    }

}
