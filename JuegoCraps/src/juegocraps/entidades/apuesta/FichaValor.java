/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package juegocraps.entidades.apuesta;

/**
 *
 * @author Yakko
 */
public class FichaValor {
    
    private String cantidad;
    private String valor;
    
    public FichaValor(String cantidad, String valor) {
        this.cantidad = cantidad;
        this.valor = valor;
    }

    public String getCantidad() {
        return cantidad;
    }

    public String getValor() {
        return valor;
    }
    
}
