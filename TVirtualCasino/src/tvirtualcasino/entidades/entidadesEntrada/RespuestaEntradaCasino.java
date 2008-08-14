/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcasino.entidades.entidadesEntrada;

import java.util.ArrayList;
import java.util.List;
import tvirtualcasino.entidades.Usuario;
import tvirtualcasino.entidades.Vterm;
import tvirtualcasino.entidades.entidadesEstadoCasino.ValorFicha;
/**
 *
 * @author Yakko
 */
public class RespuestaEntradaCasino {
    
    private Vterm vTerm;    
    private Usuario usuario;    
    private String aceptado;
    private String modoAcceso;
    private String saldo;
    private String descripcion;
    private List fichasHabilitadas = new ArrayList();

    public RespuestaEntradaCasino(Vterm vTerm, Usuario usuario, String aceptado, String modoAcceso, String saldo, String descripcion) {
        this.vTerm = vTerm;
        this.usuario = usuario;
        this.aceptado = aceptado;
        this.modoAcceso = modoAcceso;
        this.saldo = saldo;
        this.descripcion = descripcion;
    }
    
    public void addFichasHabilitadas(ValorFicha valorFicha) {
        fichasHabilitadas.add(valorFicha);
    }

    public List getFichasHabilitadas() {
        return fichasHabilitadas;
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

    public String getSaldo() {
        return saldo;
    }

    public Usuario getUsuario() {
        return usuario;
    }

    public Vterm getVTerm() {
        return vTerm;
    }
    
}
