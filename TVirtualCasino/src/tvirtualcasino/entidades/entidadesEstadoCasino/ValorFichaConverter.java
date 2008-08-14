/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tvirtualcasino.entidades.entidadesEstadoCasino;

import com.thoughtworks.xstream.converters.basic.AbstractSingleValueConverter;

/**
 *
 * @author Yakko
 */
public class ValorFichaConverter extends AbstractSingleValueConverter {

    public boolean canConvert(Class clazz) {
        return clazz.equals(ValorFicha.class);
    }

    public Object fromString(String str) {
        ValorFicha valorFicha = new ValorFicha();
        valorFicha.setValor(str);
        return valorFicha;
    }
}

