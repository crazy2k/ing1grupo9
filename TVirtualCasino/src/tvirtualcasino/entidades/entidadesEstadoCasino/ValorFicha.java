/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcasino.entidades.entidadesEstadoCasino;

/**
 *
 * @author Yakko
 */
public class ValorFicha {
    
    public ValorFicha(String nombre) {
        this.valor = nombre;
    }
    
    public ValorFicha () {}
    
    private String valor;

    public String getValor() {
        return valor;
    }

    public void setValor(String valor) {
        this.valor = valor;
    }

    
    public String toString() {
        return getValor();
    }

}
