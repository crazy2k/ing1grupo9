/*
 * Entrada.java
 *
 * Created on 4 de julio de 2008, 07:57
 */

package tvirtualcasino;

import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.SwingUtilities;
import com.thoughtworks.xstream.*;

import com.thoughtworks.xstream.io.xml.DomDriver;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.util.Iterator;
import javax.swing.DefaultComboBoxModel;
import tvirtualcasino.entidades.entidadesEntrada.EntradaCasino;
import tvirtualcasino.entidades.Usuario;
import tvirtualcasino.entidades.UsuarioConverter;
import tvirtualcasino.entidades.VTermConverter;
import tvirtualcasino.entidades.Vterm;
import tvirtualcasino.entidades.entidadesEntrada.RespuestaEntradaCasino;
import tvirtualcasino.entidades.entidadesEstadoCasino.ValorFicha;
import tvirtualcasino.entidades.entidadesEstadoCasino.ValorFichaConverter;


/**
 *
 * @author  iiacobac
 */
public class Entrada extends javax.swing.JFrame {

    /** Creates new form Entrada */
    public Entrada() {
        initComponents();
    }

    /** This method is called from within the constructor to
     * initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is
     * always regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        modoIngreso = new javax.swing.ButtonGroup();
        jPanel1 = new javax.swing.JPanel();
        jPanel2 = new javax.swing.JPanel();
        jRadioJugador = new javax.swing.JRadioButton();
        jRadioObservador = new javax.swing.JRadioButton();
        jLabel2 = new javax.swing.JLabel();
        jTextUsuario = new javax.swing.JTextField();
        jButtonAceptar = new javax.swing.JButton();
        jPanel3 = new javax.swing.JPanel();
        jTextIdTerminal = new javax.swing.JTextField();
        jLabel1 = new javax.swing.JLabel();
        jTextIdGrupo = new javax.swing.JTextField();
        jLabel3 = new javax.swing.JLabel();

        modoIngreso.add(jRadioJugador);
        modoIngreso.add(jRadioObservador);

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("Ingreso");
        setName("frameIngreso"); // NOI18N
        setResizable(false);

        jPanel1.setBorder(javax.swing.BorderFactory.createTitledBorder("Ingreso"));

        jPanel2.setBorder(javax.swing.BorderFactory.createTitledBorder("Modo de Ingreso"));

        jRadioJugador.setSelected(true);
        jRadioJugador.setText("Jugador");
        jRadioJugador.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jRadioJugadorActionPerformed(evt);
            }
        });

        jRadioObservador.setText("Observador");
        jRadioObservador.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jRadioObservadorActionPerformed(evt);
            }
        });

        org.jdesktop.layout.GroupLayout jPanel2Layout = new org.jdesktop.layout.GroupLayout(jPanel2);
        jPanel2.setLayout(jPanel2Layout);
        jPanel2Layout.setHorizontalGroup(
            jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jPanel2Layout.createSequentialGroup()
                .add(jRadioJugador, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 83, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .add(jRadioObservador))
        );
        jPanel2Layout.setVerticalGroup(
            jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jRadioJugador)
            .add(jRadioObservador)
        );

        jRadioJugador.getAccessibleContext().setAccessibleName("jRadioJugador");

        jLabel2.setText("Nombre Usuario");

        jTextUsuario.setMaximumSize(new java.awt.Dimension(100, 20));
        jTextUsuario.setMinimumSize(new java.awt.Dimension(100, 20));
        jTextUsuario.setPreferredSize(new java.awt.Dimension(100, 20));

        org.jdesktop.layout.GroupLayout jPanel1Layout = new org.jdesktop.layout.GroupLayout(jPanel1);
        jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(
            jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jPanel1Layout.createSequentialGroup()
                .addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .add(jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(jTextUsuario, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 153, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel2)
                    .add(jPanel2, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)))
        );
        jPanel1Layout.setVerticalGroup(
            jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jPanel1Layout.createSequentialGroup()
                .addContainerGap()
                .add(jLabel2)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(jTextUsuario, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(jPanel2, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        jButtonAceptar.setText("Aceptar");
        jButtonAceptar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonAceptarActionPerformed(evt);
            }
        });

        jPanel3.setBorder(javax.swing.BorderFactory.createTitledBorder("Terminal"));

        jTextIdTerminal.setMaximumSize(new java.awt.Dimension(44, 20));
        jTextIdTerminal.setMinimumSize(new java.awt.Dimension(44, 20));
        jTextIdTerminal.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jTextIdTerminalActionPerformed(evt);
            }
        });

        jLabel1.setText("Identificador Terminal");

        jTextIdGrupo.setMaximumSize(new java.awt.Dimension(44, 20));
        jTextIdGrupo.setMinimumSize(new java.awt.Dimension(44, 20));
        jTextIdGrupo.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jTextIdGrupoActionPerformed(evt);
            }
        });

        jLabel3.setText("Identificador Grupo");

        org.jdesktop.layout.GroupLayout jPanel3Layout = new org.jdesktop.layout.GroupLayout(jPanel3);
        jPanel3.setLayout(jPanel3Layout);
        jPanel3Layout.setHorizontalGroup(
            jPanel3Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jPanel3Layout.createSequentialGroup()
                .addContainerGap()
                .add(jPanel3Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(jPanel3Layout.createSequentialGroup()
                        .add(jTextIdGrupo, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 38, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(jLabel3))
                    .add(jPanel3Layout.createSequentialGroup()
                        .add(jTextIdTerminal, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 52, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(jLabel1)))
                .addContainerGap(20, Short.MAX_VALUE))
        );
        jPanel3Layout.setVerticalGroup(
            jPanel3Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jPanel3Layout.createSequentialGroup()
                .addContainerGap()
                .add(jPanel3Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jTextIdGrupo, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel3))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(jPanel3Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel1)
                    .add(jTextIdTerminal, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        org.jdesktop.layout.GroupLayout layout = new org.jdesktop.layout.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(layout.createSequentialGroup()
                .addContainerGap()
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(org.jdesktop.layout.GroupLayout.TRAILING, layout.createSequentialGroup()
                        .add(jButtonAceptar)
                        .add(75, 75, 75))
                    .add(layout.createSequentialGroup()
                        .add(jPanel3, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                        .addContainerGap())
                    .add(layout.createSequentialGroup()
                        .add(jPanel1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                        .addContainerGap())))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(layout.createSequentialGroup()
                .addContainerGap()
                .add(jPanel3, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(jPanel1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(jButtonAceptar)
                .addContainerGap(14, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

private void jRadioObservadorActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jRadioObservadorActionPerformed
// TODO add your handling code here:
}//GEN-LAST:event_jRadioObservadorActionPerformed

private void jRadioJugadorActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jRadioJugadorActionPerformed
// TODO add your handling code here:
}//GEN-LAST:event_jRadioJugadorActionPerformed

    @SuppressWarnings("empty-statement")
private void jButtonAceptarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonAceptarActionPerformed
    
    String vTerm = "0000" + this.jTextIdTerminal.getText();
    vTerm = vTerm.substring(vTerm.length()-4, vTerm.length());
    String grupo = "00" + this.jTextIdGrupo.getText();
    grupo = grupo.substring(grupo.length()-2, grupo.length());
    String usuario = this.jTextUsuario.getText();
    String tipoIngreso;

    if (this.jRadioJugador.isSelected()) {
        tipoIngreso = "jugador";
    } else {
        tipoIngreso = "observador";
    }

    EntradaCasino entradaCasino = new EntradaCasino(new Vterm(vTerm), new Usuario(usuario), tipoIngreso);
    XStream xstream = new XStream();

    xstream.alias("entradaCasino", EntradaCasino.class);
    xstream.useAttributeFor(EntradaCasino.class, "vTerm");
    xstream.registerConverter(new VTermConverter());

    xstream.useAttributeFor(EntradaCasino.class, "usuario");
    xstream.registerConverter(new UsuarioConverter());


    String xml = xstream.toXML(entradaCasino);
    xml = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>\n" + xml;
    System.out.println(xml);

    FileWriter file;
    try {
    file = new FileWriter("/Temp/Servidor/entradaCasino" + grupo + vTerm + ".xml");
    file.write(xml);
    file.close();

    } catch (IOException ex) {
       Logger.getLogger(Entrada.class.getName()).log(Level.SEVERE, null, ex);
    } 
    
    String archivo = "/Temp/respuestaEntradaCasino" + grupo  + vTerm + ".xml";
    while (!(new File(archivo)).exists());
  
    StringBuffer buff = new StringBuffer();
    
    try {
        FileReader fileR = new FileReader(archivo);
    
        fileR.read();

        int c;
        while ((c = fileR.read()) != -1) {
            buff.append(Character.toChars(c)[0]);
        }
        
        fileR.close();
        
        while (!(new File(archivo)).delete());
        

    } catch (IOException ex) {
        
    }
    
    String xml2 = buff.toString();
    
    xml2 = xml2.substring(xml2.indexOf("?>") + 3);
    
    //System.out.println(xml2);
            
     
    XStream xstream1 = new XStream(new DomDriver());
    xstream1.registerConverter(new ValorFichaConverter());
    xstream1.alias("valorFicha", ValorFicha.class);
    xstream1.alias("entradaCasino", RespuestaEntradaCasino.class);
    xstream1.useAttributeFor(RespuestaEntradaCasino.class, "vTerm");
    xstream1.registerConverter(new VTermConverter());
    xstream1.useAttributeFor(RespuestaEntradaCasino.class, "usuario");
    xstream1.registerConverter(new UsuarioConverter());
    RespuestaEntradaCasino e = (RespuestaEntradaCasino)xstream1.fromXML(xml2);

    if ("no".equals(e.getAceptado())) {
        DenegacionIngreso d = new DenegacionIngreso();
        d.setMotivoDenegacion(e.getDescripcion());
        d.setVisible(true);        
    } else if ("si".equals(e.getAceptado())) {
        Ingresado i = new Ingresado();
        i.setUsuario(e.getUsuario().getNombre());
        i.setSaldo(e.getSaldo());
        i.setModoIngreso("jugador".equals(e.getModoAcceso())?1:0);
        i.setMotivoAceptacion(e.getDescripcion());
        i.setVTerm(e.getVTerm());
        i.setUsuario(e.getUsuario());
        
    String grupo2 = "00" + this.jTextIdGrupo.getText();
    grupo2 = grupo2.substring(grupo2.length()-2, grupo2.length());
        
        i.setGrupo(grupo2);
        i.setFichas(e.getFichasHabilitadas());
        i.setVisible(true); 
   
    }
    
    

    /////////////////////////////////////////////////////////////////////////

/*
            String xml2 = "<entradaCasino vTerm=\"1\" usuario=\"pepe\">\n" +
            "<aceptado>si</aceptado>\n" +
            "<modoAcceso>jugador</modoAcceso>\n" +
            "<saldo>10</saldo>\n" +
            "<descripcion>Ok!!</descripcion>\n" +
            "</entradaCasino>";
             */
            /*
            XStream xstream1 = new XStream(new DomDriver());
            xstream1.alias("entradaCasino", RespuestaEntradaCasino.class);
            xstream1.useAttributeFor(RespuestaEntradaCasino.class, "vTerm");
            xstream1.registerConverter(new VTermConverter());
            xstream1.useAttributeFor(RespuestaEntradaCasino.class, "usuario");
            xstream1.registerConverter(new UsuarioConverter());
            RespuestaEntradaCasino e = (RespuestaEntradaCasino)xstream1.fromXML(xml);
            XStream xstream2 = new XStream();
            xstream2.alias("entradaCasino", EntradaCasinoAceptada.class);
            xstream2.useAttributeFor(EntradaCasinoAceptada.class, "vTerm");
            xstream2.registerConverter(new VTermConverter());
            xstream2.useAttributeFor(EntradaCasinoAceptada.class, "usuario");
            xstream2.registerConverter(new UsuarioConverter());
            //System.out.print(e);
            System.out.print(xstream1.toXML(e));
             */

         /*   
            Craps craps = new Craps();
            MesaCraps mesaCraps = new MesaCraps("1",
            new ProximoTiro("Pepe", "si", ""), new UltimoTiro("Juan", "1"));
            MesaCraps mesaCraps1 = new MesaCraps("3",
            new ProximoTiro("Pedro", "no", "4"), new UltimoTiro("Pedro", "2"));
            mesaCraps.addJugador(new Jugador("Pepe"));
            mesaCraps.addJugador(new Jugador("Juan"));
            mesaCraps1.addJugador(new Jugador("Pedro"));
            craps.addMesaCraps(mesaCraps);
            craps.addMesaCraps(mesaCraps1);
            Tragamonedas tr = new Tragamonedas("10");
            Juego juego = new Juego(tr, craps);
            PozosCasino pozosCasino = new PozosCasino("10");
            RespuestaEstadoCasino rta = new RespuestaEstadoCasino(new Vterm("1"), new Usuario("Ignacio"), juego, pozosCasino);
            rta.addJugador(new Jugador("Pepe"));
            rta.addJugador(new Jugador("Juan"));
            rta.addJugador(new Jugador("Pedro"));
            rta.addObservador(new Observador("Osvaldo"));
            XStream xstream = new XStream();
            xstream.alias("jugador", Jugador.class);
            xstream.alias("mesaCraps", MesaCraps.class);
            xstream.useAttributeFor(MesaCraps.class, "id");
            xstream.registerConverter(new IdConverter());
            xstream.registerConverter(new JugadorConverter());
            xstream.registerConverter(new ObservadorConverter());
            xstream.alias("observador", Observador.class);
            xstream.alias("jugador", Jugador.class);
            xstream.alias("craps", Craps.class);
            xstream.alias("tragamonedas", Tragamonedas.class);
            xstream.alias("juegos", Juego.class);
            xstream.alias("pozosCasino", PozosCasino.class);
            xstream.alias("estadoCasino", RespuestaEstadoCasino.class);
            xstream.useAttributeFor(EstadoCasino.class, "vTerm");
            xstream.registerConverter(new VTermConverter());
            xstream.useAttributeFor(EstadoCasino.class, "usuario");
            xstream.registerConverter(new UsuarioConverter());
            //String xml = xstream.toXML(craps);
            String xml = xstream.toXML(rta);
            xml = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>\n" + xml;
            System.out.println(xml);
             

    */
    

    
    
    
/*    
    String xml2 = "<entradaCasino vTerm=\"1\" usuario=\"pepe\">\n" +
                   "<aceptado>si</aceptado>\n" +
                   "<modoAcceso>jugador</modoAcceso>\n" +
                   "<saldo>10</saldo>\n" +
                   "<descripcion>Ok!!</descripcion>\n" +
                   "</entradaCasino>";
  */ /*
    XStream xstream1 = new XStream(new DomDriver());
    
    xstream1.alias("entradaCasino", RespuestaEntradaCasino.class);
    xstream1.useAttributeFor(RespuestaEntradaCasino.class, "vTerm");
    xstream1.registerConverter(new VTermConverter());
    
    xstream1.useAttributeFor(RespuestaEntradaCasino.class, "usuario");
    xstream1.registerConverter(new UsuarioConverter());
    
    RespuestaEntradaCasino e = (RespuestaEntradaCasino)xstream1.fromXML(xml);
    
    XStream xstream2 = new XStream();
    
    xstream2.alias("entradaCasino", EntradaCasinoAceptada.class);
    xstream2.useAttributeFor(EntradaCasinoAceptada.class, "vTerm");
    xstream2.registerConverter(new VTermConverter());
    
    xstream2.useAttributeFor(EntradaCasinoAceptada.class, "usuario");
    xstream2.registerConverter(new UsuarioConverter());
    //System.out.print(e);
    System.out.print(xstream1.toXML(e));
     */
    
    /*
    Craps craps = new Craps();
    
    
    MesaCraps mesaCraps = new MesaCraps("1", 
         new ProximoTiro("Pepe", "si", ""), new UltimoTiro("Juan", "1"));
    
    MesaCraps mesaCraps1 = new MesaCraps("3", 
         new ProximoTiro("Pedro", "no", "4"), new UltimoTiro("Pedro", "2"));
    
    mesaCraps.addJugador(new Jugador("Pepe"));
    mesaCraps.addJugador(new Jugador("Juan"));
    mesaCraps1.addJugador(new Jugador("Pedro"));
    
    craps.addMesaCraps(mesaCraps);
    craps.addMesaCraps(mesaCraps1);
        
    Tragamonedas tr = new Tragamonedas("10");
    
    Juego juego = new Juego(tr, craps);
    
    PozosCasino pozosCasino = new PozosCasino("10");
    
    RespuestaEstadoCasino rta = new RespuestaEstadoCasino(new Vterm("1"), new Usuario("Ignacio"), juego, pozosCasino);
    
    rta.addJugador(new Jugador("Pepe"));
    rta.addJugador(new Jugador("Juan"));
    rta.addJugador(new Jugador("Pedro"));
    
    rta.addObservador(new Observador("Osvaldo"));    

    XStream xstream = new XStream();

    xstream.alias("jugador", Jugador.class);
    xstream.alias("mesaCraps", MesaCraps.class);
    xstream.useAttributeFor(MesaCraps.class, "id");
    xstream.registerConverter(new IdConverter());
    xstream.registerConverter(new JugadorConverter());
    xstream.registerConverter(new ObservadorConverter());
    xstream.alias("observador", Observador.class);
    xstream.alias("jugador", Jugador.class);
    xstream.alias("craps", Craps.class);
    xstream.alias("tragamonedas", Tragamonedas.class);
    xstream.alias("juegos", Juego.class);
    xstream.alias("pozosCasino", PozosCasino.class);
    xstream.alias("estadoCasino", RespuestaEstadoCasino.class);
    xstream.useAttributeFor(EstadoCasino.class, "vTerm");
    xstream.registerConverter(new VTermConverter());
    xstream.useAttributeFor(EstadoCasino.class, "usuario");
    xstream.registerConverter(new UsuarioConverter());
    
    //String xml = xstream.toXML(craps);
    String xml = xstream.toXML(rta);
    xml = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>\n" + xml;
    System.out.println(xml);
     */
    
}//GEN-LAST:event_jButtonAceptarActionPerformed

private void jTextIdTerminalActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jTextIdTerminalActionPerformed
// TODO add your handling code here:
}//GEN-LAST:event_jTextIdTerminalActionPerformed

private void jTextIdGrupoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jTextIdGrupoActionPerformed
// TODO add your handling code here:
}//GEN-LAST:event_jTextIdGrupoActionPerformed

    /**
    * @param args the command line arguments
    */
    public static void main(String args[]) {
        SwingUtilities.invokeLater(new Runnable() {
            public void run() {
                new Entrada().setVisible(true);
                
                
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton jButtonAceptar;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JPanel jPanel2;
    private javax.swing.JPanel jPanel3;
    private javax.swing.JRadioButton jRadioJugador;
    private javax.swing.JRadioButton jRadioObservador;
    private javax.swing.JTextField jTextIdGrupo;
    private javax.swing.JTextField jTextIdTerminal;
    private javax.swing.JTextField jTextUsuario;
    private javax.swing.ButtonGroup modoIngreso;
    // End of variables declaration//GEN-END:variables

}