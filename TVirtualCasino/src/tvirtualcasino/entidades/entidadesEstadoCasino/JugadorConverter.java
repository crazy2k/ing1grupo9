/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcasino.entidades.entidadesEstadoCasino;

import com.thoughtworks.xstream.converters.basic.AbstractSingleValueConverter;


/**
 *
 * @author iiacobac
 */
public class JugadorConverter extends AbstractSingleValueConverter {

    public boolean canConvert(Class clazz) {
        return clazz.equals(Jugador.class);
    }

    public Object fromString(String str) {
        Jugador jugador = new Jugador();
        jugador.setNombre(str);
        return jugador;
    }
}
