/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcasino.entidades.entidadesEstadoCasino;

import java.util.ArrayList;
import java.util.List;
import tvirtualcasino.entidades.Usuario;
import tvirtualcasino.entidades.Vterm;

/**
 *
 * @author iiacobac
 */
public class RespuestaEstadoCasino {
    
    private Vterm vTerm;    
    private Usuario usuario;
    private List jugadores = new ArrayList();
    private List observadores  = new ArrayList();
    private Juego juego;
    private PozosCasino pozos;

    public RespuestaEstadoCasino(Vterm vTerm, Usuario usuario, Juego juego, PozosCasino pozos) {
        this.vTerm = vTerm;
        this.usuario = usuario;
        this.juego = juego;
        this.pozos = pozos;
    }

    public Usuario getUsuario() {
        return usuario;
    }

    public Vterm getVTerm() {
        return vTerm;
    }

    public Juego getJuego() {
        return juego;
    }

    public PozosCasino getPozos() {
        return pozos;
    }
    
    public void addJugador(Jugador jugador) {
        jugadores.add(jugador);
    }
    
    public void addObservador(Observador observador) {
        observadores.add(observador);        
    }
    
    public List getJugadores() {
        return jugadores;
    }

    public List getObservadores() {
        return observadores;
    }

}
