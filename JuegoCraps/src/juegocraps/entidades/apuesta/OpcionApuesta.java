/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package juegocraps.entidades.apuesta;

/**
 *
 * @author Yakko
 */
public class OpcionApuesta {
    
    private String tipoApuesta;
    private String puntajeApostado;

    public OpcionApuesta(String tipoApuesta, String puntajeApostado) {
        this.tipoApuesta = tipoApuesta;
        this.puntajeApostado = puntajeApostado;
    }

    public String getPuntajeApostado() {
        return puntajeApostado;
    }

    public String getTipoApuesta() {
        return tipoApuesta;
    }    

}
