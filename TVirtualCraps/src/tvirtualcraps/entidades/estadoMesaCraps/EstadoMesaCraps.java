/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcraps.entidades.estadoMesaCraps;

import java.util.ArrayList;
import java.util.List;
import tvirtualcraps.entidades.Mesa;
import tvirtualcraps.entidades.Usuario;
import tvirtualcraps.entidades.Vterm;

/**
 *
 * @author Yakko
 */
public class EstadoMesaCraps {
    
    private Vterm vTerm;    
    private Usuario usuario;    
    private Mesa mesa;
    private List jugadores = new ArrayList();
    private ProximoTiro proximoTiro;
    private UltimoTiro ultimoTiro;
    private List apuestasVigentes = new ArrayList();

    public EstadoMesaCraps(Vterm vTerm, Usuario usuario, Mesa mesa, ProximoTiro proximoTiro, UltimoTiro ultimoTiro) {
        this.vTerm = vTerm;
        this.usuario = usuario;
        this.mesa = mesa;
        this.proximoTiro = proximoTiro;
        this.ultimoTiro = ultimoTiro;
    }
    
    public void addJugador(Jugador jugador) {
        jugadores.add(jugador);
    }
    
    public void addApuesta(Apuesta apuesta) {
        apuestasVigentes.add(apuesta);
    }

    public List getApuestasVigentes() {
        return apuestasVigentes;
    }

    public List getJugadores() {
        return jugadores;
    }

    public Mesa getMesa() {
        return mesa;
    }

    public ProximoTiro getProximoTiro() {
        return proximoTiro;
    }

    public UltimoTiro getUltimoTiro() {
        return ultimoTiro;
    }

    public Usuario getUsuario() {
        return usuario;
    }

    public Vterm getVTerm() {
        return vTerm;
    }
    
    

}
