/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcasino.entidades.entidadesEstadoCasino.Juegos;

/**
 *
 * @author iiacobac
 */
public class UltimoTiro {
    
    private String tirador;
    private String resultado;

    public UltimoTiro(String tirador, String resultado) {
        this.tirador = tirador;
        this.resultado = resultado;
    }

    public String getResultado() {
        return resultado;
    }

    public String getTirador() {
        return tirador;
    }

}
