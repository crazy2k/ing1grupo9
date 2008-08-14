/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package juegocraps.entidades;

/**
 *
 * @author Yakko
 */
public class Resultado {
    
    private String dado1;
    private String dado2;

    public Resultado(String dado1, String dado2) {
        this.dado1 = dado1;
        this.dado2 = dado2;
    }

    public String getDado1() {
        return dado1;
    }

    public String getDado2() {
        return dado2;
    }

}
