/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcraps.entidades.estadoMesaCraps;

/**
 *
 * @author Yakko
 */
public class Premio {
    
    private String apostador;
    private String montoPremioJugada;
    private String montoPremioJugadaFeliz;
    private String montoRetenidoJugadaTodosponen;

    public Premio(String apostador, String montoPremioJugada, String montoPremioJugadaFeliz, String montoRetenidoJugadaTodosponen) {
        this.apostador = apostador;
        this.montoPremioJugada = montoPremioJugada;
        this.montoPremioJugadaFeliz = montoPremioJugadaFeliz;
        this.montoRetenidoJugadaTodosponen = montoRetenidoJugadaTodosponen;
    }

    public String getApostador() {
        return apostador;
    }

    public String getMontoPremioJugada() {
        return montoPremioJugada;
    }

    public String getMontoPremioJugadaFeliz() {
        return montoPremioJugadaFeliz;
    }

    public String getMontoRetenidoJugadaTodosponen() {
        return montoRetenidoJugadaTodosponen;
    }

}
