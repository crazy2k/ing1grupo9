/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcasino.entidades.entidadesEstadoCasino.Juegos;

import java.util.ArrayList;
import java.util.List;
import tvirtualcasino.entidades.entidadesEstadoCasino.Jugador;

/**
 *
 * @author iiacobac
 */
public class MesaCraps {
    
    private String id;
    private List jugadores = new ArrayList();
    private ProximoTiro proximoTiro;
    private UltimoTiro ultimoTiro;

    public MesaCraps(String id, ProximoTiro proximoTiro, UltimoTiro ultimoTiro) {
        this.id = id;
        this.proximoTiro = proximoTiro;
        this.ultimoTiro = ultimoTiro;        
    }
    
    public void addJugador(Jugador jugador) {
        jugadores.add(jugador);
    }

    public String getId() {
        return id;
    }

    public List getJugadores() {
        return jugadores;
    }

    public ProximoTiro getProximoTiro() {
        return proximoTiro;
    }

    public UltimoTiro getUltimoTiro() {
        return ultimoTiro;
    }

    public boolean equals(MesaCraps mesa) {
        return (this.getId().equals(mesa.getId()));
    }

}
