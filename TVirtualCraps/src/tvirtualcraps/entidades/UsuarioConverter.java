/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcraps.entidades;

import tvirtualcraps.entidades.Usuario;
import com.thoughtworks.xstream.converters.SingleValueConverter;

/**
 *
 * @author Yakko
 */
public class UsuarioConverter implements SingleValueConverter {

    public String toString(Object obj) {
            return ((Usuario) obj).getNombre();
    }

    public Object fromString(String name) {
            return new Usuario(name);
    }

    public boolean canConvert(Class type) {
            return type.equals(Usuario.class);
    }


}
