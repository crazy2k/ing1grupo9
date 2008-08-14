/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcasino.entidades.entidadesEstadoCasino.Juegos;

/**
 *
 * @author iiacobac
 */
public class ProximoTiro {
    
    private String tirador;
    private String tiroSalida;
    private String punto;

    public ProximoTiro(String tirador, String tiroSalida, String punto) {
        this.tirador = tirador;
        this.tiroSalida = tiroSalida;
        this.punto = punto;
    }

    public String getPunto() {
        return punto;
    }

    public String getTirador() {
        return tirador;
    }

    public String getTiroSalida() {
        return tiroSalida;
    }

}
