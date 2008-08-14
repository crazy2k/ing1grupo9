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
public class ObservadorConverter extends AbstractSingleValueConverter {

    public boolean canConvert(Class clazz) {
        return clazz.equals(Observador.class);
    }

    public Object fromString(String str) {
        Observador observador = new Observador();
        observador.setNombre(str);
        return observador;
    }
}
