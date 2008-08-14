/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcraps.entidades.estadoMesaCraps;

/**
 *
 * @author iiacobac
 */
public class Jugador {

    public Jugador(String nombre) {
        this.nombre = nombre;
    }
    
    public Jugador () {}
    
    private String nombre;

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    
    public String toString() {
        return getNombre();
    }

}
