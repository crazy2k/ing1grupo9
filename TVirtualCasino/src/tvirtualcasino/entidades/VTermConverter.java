/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcasino.entidades;

import com.thoughtworks.xstream.converters.SingleValueConverter;

/**
 *
 * @author Yakko
 */
public class VTermConverter implements SingleValueConverter  {

    public String toString(Object obj) {
        return ((Vterm) obj).getId();
    }

    public Object fromString(String vterm) {
        return new Vterm(vterm);
    }

    public boolean canConvert(Class type) {
        return type.equals(Vterm.class);
    }

}
