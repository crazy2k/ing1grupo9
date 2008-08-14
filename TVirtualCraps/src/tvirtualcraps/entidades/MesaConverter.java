/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcraps.entidades;

import com.thoughtworks.xstream.converters.SingleValueConverter;

/**
 *
 * @author Yakko
 */
public class MesaConverter implements SingleValueConverter {
    
    public String toString(Object obj) {
            return ((Mesa) obj).getNombre();
    }

    public Object fromString(String name) {
            return new Mesa(name);
    }

    public boolean canConvert(Class type) {
            return type.equals(Mesa.class);
    }

}
