/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcasino.entidades.entidadesEntradaAceptada;

import tvirtualcasino.entidades.Usuario;
import tvirtualcasino.entidades.Vterm;
/**
 *
 * @author Yakko
 */
public class EntradaCasinoAceptada {
    
    private Vterm vTerm;    
    private Usuario usuario;    
    private String aceptado;
    private String modoAcceso;
    private double saldo;
    private String descripcion;

    public EntradaCasinoAceptada(Vterm vTerm, Usuario usuario, String aceptado, String modoAcceso, double saldo, String descripcion) {
        this.vTerm = vTerm;
        this.usuario = usuario;
        this.aceptado = aceptado;
        this.modoAcceso = modoAcceso;
        this.saldo = saldo;
        this.descripcion = descripcion;
    }

    public String getAceptado() {
        return aceptado;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public String getModoAcceso() {
        return modoAcceso;
    }

    public double getSaldo() {
        return saldo;
    }

    public Usuario getUsuario() {
        return usuario;
    }

    public Vterm getVTerm() {
        return vTerm;
    }
    
}
