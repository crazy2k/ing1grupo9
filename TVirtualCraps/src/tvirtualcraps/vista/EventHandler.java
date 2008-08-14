/*
 * EventHandler.java
 *
 * Created on 9 de julio de 2008, 23:06
 */

package tvirtualcraps.vista;

import com.thoughtworks.xstream.XStream;
import com.thoughtworks.xstream.io.xml.DomDriver;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.File;
import java.io.IOException;
import java.util.Iterator;
import javax.swing.DefaultComboBoxModel;
import tvirtualcraps.entidades.Mesa;
import tvirtualcraps.entidades.MesaConverter;
import tvirtualcraps.entidades.Usuario;
import tvirtualcraps.entidades.UsuarioConverter;
import tvirtualcraps.entidades.VTermConverter;
import tvirtualcraps.entidades.Vterm;
import tvirtualcraps.entidades.estadoMesaCraps.Apuesta;
import tvirtualcraps.entidades.estadoMesaCraps.EstadoMesaCraps;
import tvirtualcraps.entidades.estadoMesaCraps.FichaValor;
import tvirtualcraps.entidades.estadoMesaCraps.Jugador;
import tvirtualcraps.entidades.estadoMesaCraps.JugadorConverter;
import tvirtualcraps.entidades.estadoMesaCraps.OpcionApuesta;
import tvirtualcraps.entidades.estadoMesaCraps.Premio;
import tvirtualcraps.entidades.estadoMesaCraps.ProximoTiro;
import tvirtualcraps.entidades.estadoMesaCraps.UltimoTiro;

/**
 *
 * @author  Yakko
 */
public class EventHandler extends javax.swing.JFrame {
    
    private String grupo; 
    private String vTerm;

    /** Creates new form EventHandler */
    @SuppressWarnings("empty-statement")
    public EventHandler(String grupo, String vTerm) {
        initComponents();
        this.grupo = grupo;
        this.vTerm = vTerm;
    }
    
    public void readState() {
        grupo = this.grupo;
        vTerm = this.vTerm;
        /*
        UltimoTiro ultimoTiro = new UltimoTiro("Ykk", "2");
        
        ultimoTiro.addPremio(new Premio("Pepe", "10", "", ""));
        ultimoTiro.addPremio(new Premio("Juan", "5", "", ""));
                
        EstadoMesaCraps estado = new EstadoMesaCraps(
                                       new Vterm("0001"), 
                                       new Usuario("Ykk"),
                                       new Mesa("10"), 
                                       new ProximoTiro("Ykk", "10", "6"), 
                                       ultimoTiro);
        
        estado.addJugador(new Jugador("Ykk"));
        estado.addJugador(new Jugador("Pepe"));
        estado.addJugador(new Jugador("Juan"));
        
        Apuesta apuesta1 = new Apuesta("Pepe", new OpcionApuesta("venir", "1"));
        apuesta1.addFichaValor(new FichaValor("1", "1"));
        
        Apuesta apuesta2 = new Apuesta("Pepe", new OpcionApuesta("venir", "10"));
        apuesta2.addFichaValor(new FichaValor("5", "1"));
        apuesta2.addFichaValor(new FichaValor("1", "5"));
        
        estado.addApuesta(apuesta1);
        estado.addApuesta(apuesta2);
        
        XStream xstream = new XStream(new DomDriver());
    
        xstream.alias("estadoMesaCraps", EstadoMesaCraps.class);
        xstream.useAttributeFor(EstadoMesaCraps.class, "vTerm");
        xstream.registerConverter(new VTermConverter());
        xstream.useAttributeFor(EstadoMesaCraps.class, "usuario");
        xstream.registerConverter(new UsuarioConverter());
        xstream.useAttributeFor(EstadoMesaCraps.class, "mesa");
        xstream.registerConverter(new MesaConverter());
        xstream.registerConverter(new JugadorConverter());
        xstream.alias("jugador", Jugador.class);
        xstream.alias("premio", Premio.class);
        xstream.alias("apuesta", Apuesta.class);
        xstream.alias("fichaValor", FichaValor.class); 
        
        String xml = xstream.toXML(estado);
        xml = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>\n" + xml;
        //System.out.println(xml);

        FileWriter file;
        try {
        file = new FileWriter("/Temp/estadoCraps" + grupo + vTerm + ".xml");
        file.write(xml);
        file.close();

        } catch (IOException ex) {
           System.err.println("Error en generacion archivo de tiro");
        } 
         **/ 
        
            long versionActual = 0;
        
        //while(true) {
        
            while ((new File("/Temp/estadoCraps" + grupo + vTerm + ".xml")).lastModified() == versionActual);

            versionActual = (new File("/Temp/estadoCraps" + grupo + vTerm + ".xml")).lastModified();

            StringBuffer buff = new StringBuffer();

            try {
                FileReader fileR = new FileReader("/Temp/estadoCraps" + grupo + vTerm + ".xml");

                fileR.read();

                int c;
                while ((c = fileR.read()) != -1) {
                    buff.append(Character.toChars(c)[0]);
                }

            } catch (IOException ex) {

            }

            String xml2 = buff.toString();

            xml2 = xml2.substring(xml2.indexOf("?>") + 3);

            //System.out.println(xml2);


            XStream xstream = new XStream(new DomDriver());

            xstream.alias("estadoMesaCraps", EstadoMesaCraps.class);
            xstream.useAttributeFor(EstadoMesaCraps.class, "vTerm");
            xstream.registerConverter(new VTermConverter());
            xstream.useAttributeFor(EstadoMesaCraps.class, "usuario");
            xstream.registerConverter(new UsuarioConverter());
            xstream.useAttributeFor(EstadoMesaCraps.class, "mesa");
            xstream.registerConverter(new MesaConverter());
            xstream.registerConverter(new JugadorConverter());
            xstream.alias("jugador", Jugador.class);
            xstream.alias("premio", Premio.class);
            xstream.alias("apuesta", Apuesta.class);
            xstream.alias("fichaValor", FichaValor.class); 


            EstadoMesaCraps estado = (EstadoMesaCraps)xstream.fromXML(xml2);

            //System.out.println(estado);

            Iterator it;

            //Jugadores
            it = estado.getJugadores().iterator();         
            DefaultComboBoxModel lm = new DefaultComboBoxModel();

            while (it.hasNext()) {
                lm.addElement(it.next());
            }
            this.jListJugadores.setModel(lm);

            //Proximo Tiro
            this.jTextPunto.setText(estado.getProximoTiro().getPunto());
            this.jTextTiradorProximoTiro.setText(estado.getProximoTiro().getTirador());
            if ("si".equals(estado.getProximoTiro().getTiroSalida())) {
                this.jRadioSalidaSi.setSelected(true);
                this.jRadioSalidaNo.setSelected(false);            
            } else if ("no".equals(estado.getProximoTiro().getTiroSalida())) {
                this.jRadioSalidaSi.setSelected(false);
                this.jRadioSalidaNo.setSelected(true);
            }

            //Ultimo Tiro
            this.jTextTiradorUltimoTiro.setText(estado.getUltimoTiro().getTirador());
            this.jTextResultado.setText(estado.getUltimoTiro().getResultado());

            it = estado.getUltimoTiro().getPremios().iterator();

            lm = new DefaultComboBoxModel();

            //Premios
            while (it.hasNext()) {
                Premio premio = (Premio)it.next();
                lm.addElement(  premio.getApostador() + "-" +
                                premio.getMontoPremioJugada() + "-" +
                                premio.getMontoPremioJugadaFeliz() + "-" +
                                premio.getMontoRetenidoJugadaTodosponen()
                             );
            }
            this.jListPremios.setModel(lm);

            //Apuestas
            it = estado.getApuestasVigentes().iterator();

            lm = new DefaultComboBoxModel();

            //Premios
            while (it.hasNext()) {
                Apuesta apuesta = (Apuesta)it.next();
                String elem;

                elem = apuesta.getApostador();
                elem = elem + "-" + apuesta.getOpcionApuesta().getTipoApuesta();
                elem = elem + "-" + apuesta.getOpcionApuesta().getPuntajeApostado();

                elem = elem + "-";

                Iterator it2 = apuesta.getValorApuesta().iterator();

                while(it2.hasNext()) {
                    FichaValor ficha = (FichaValor)it2.next();
                    elem = elem + "(" + ficha.getValor() + "," + ficha.getCantidad() + ")";
                }           


                lm.addElement(elem);
            }
            this.jListApuestas.setModel(lm);
       // }

    }
    /** This method is called from within the constructor to
     * initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is
     * always regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jPanel5 = new javax.swing.JPanel();
        jScrollJugadores1 = new javax.swing.JScrollPane();
        jListJugadores = new javax.swing.JList();
        jPanel2 = new javax.swing.JPanel();
        jLabel4 = new javax.swing.JLabel();
        jTextTiradorUltimoTiro = new javax.swing.JTextField();
        jLabel5 = new javax.swing.JLabel();
        jTextResultado = new javax.swing.JTextField();
        jPanel6 = new javax.swing.JPanel();
        jLabel6 = new javax.swing.JLabel();
        jLabel8 = new javax.swing.JLabel();
        jLabel9 = new javax.swing.JLabel();
        jLabel10 = new javax.swing.JLabel();
        jScrollPane1 = new javax.swing.JScrollPane();
        jListPremios = new javax.swing.JList();
        jPanel1 = new javax.swing.JPanel();
        jLabel2 = new javax.swing.JLabel();
        jRadioSalidaSi = new javax.swing.JRadioButton();
        jRadioSalidaNo = new javax.swing.JRadioButton();
        jLabel1 = new javax.swing.JLabel();
        jTextTiradorProximoTiro = new javax.swing.JTextField();
        jTextPunto = new javax.swing.JTextField();
        jLabel3 = new javax.swing.JLabel();
        jPanel3 = new javax.swing.JPanel();
        jScrollPane2 = new javax.swing.JScrollPane();
        jListApuestas = new javax.swing.JList();
        jLabel7 = new javax.swing.JLabel();
        jButton1 = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setResizable(false);

        jPanel5.setBorder(javax.swing.BorderFactory.createTitledBorder("Jugadores"));
        jPanel5.setName("jPanel5"); // NOI18N

        jScrollJugadores1.setName("jScrollJugadores1"); // NOI18N

        jListJugadores.setName("jListJugadores"); // NOI18N
        jScrollJugadores1.setViewportView(jListJugadores);

        org.jdesktop.layout.GroupLayout jPanel5Layout = new org.jdesktop.layout.GroupLayout(jPanel5);
        jPanel5.setLayout(jPanel5Layout);
        jPanel5Layout.setHorizontalGroup(
            jPanel5Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jPanel5Layout.createSequentialGroup()
                .addContainerGap()
                .add(jScrollJugadores1, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 161, Short.MAX_VALUE)
                .addContainerGap())
        );
        jPanel5Layout.setVerticalGroup(
            jPanel5Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jPanel5Layout.createSequentialGroup()
                .add(jScrollJugadores1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        jPanel2.setBorder(javax.swing.BorderFactory.createTitledBorder("Ultimo Tiro"));
        jPanel2.setName("jPanel2"); // NOI18N

        jLabel4.setText("Tirador");
        jLabel4.setName("jLabel4"); // NOI18N

        jTextTiradorUltimoTiro.setEditable(false);
        jTextTiradorUltimoTiro.setName("jTextTiradorUltimoTiro"); // NOI18N

        jLabel5.setText("Resultado");
        jLabel5.setName("jLabel5"); // NOI18N

        jTextResultado.setEditable(false);
        jTextResultado.setName("jTextResultado"); // NOI18N

        jPanel6.setBorder(javax.swing.BorderFactory.createTitledBorder("Premios"));
        jPanel6.setName("jPanel6"); // NOI18N

        jLabel6.setText("Apostador");
        jLabel6.setVerticalAlignment(javax.swing.SwingConstants.TOP);
        jLabel6.setName("jLabel6"); // NOI18N

        jLabel8.setText("Premio Jugada");
        jLabel8.setName("jLabel8"); // NOI18N

        jLabel9.setText("Premio Jugada Feliz");
        jLabel9.setName("jLabel9"); // NOI18N

        jLabel10.setText("Retenido Jugada Todosponen");
        jLabel10.setName("jLabel10"); // NOI18N

        jScrollPane1.setName("jScrollPane1"); // NOI18N

        jListPremios.setName("jListPremios"); // NOI18N
        jScrollPane1.setViewportView(jListPremios);

        org.jdesktop.layout.GroupLayout jPanel6Layout = new org.jdesktop.layout.GroupLayout(jPanel6);
        jPanel6.setLayout(jPanel6Layout);
        jPanel6Layout.setHorizontalGroup(
            jPanel6Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jPanel6Layout.createSequentialGroup()
                .addContainerGap()
                .add(jPanel6Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(jPanel6Layout.createSequentialGroup()
                        .add(jScrollPane1, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 152, Short.MAX_VALUE)
                        .addContainerGap())
                    .add(jPanel6Layout.createSequentialGroup()
                        .add(jLabel9)
                        .addContainerGap(68, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                    .add(jPanel6Layout.createSequentialGroup()
                        .add(jLabel8)
                        .addContainerGap(92, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                    .add(jPanel6Layout.createSequentialGroup()
                        .add(jLabel6)
                        .addContainerGap(112, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                    .add(jLabel10)))
        );
        jPanel6Layout.setVerticalGroup(
            jPanel6Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jPanel6Layout.createSequentialGroup()
                .add(jLabel6)
                .add(7, 7, 7)
                .add(jLabel8)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(jLabel9)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(jLabel10)
                .add(18, 18, 18)
                .add(jScrollPane1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(17, Short.MAX_VALUE))
        );

        jLabel6.getAccessibleContext().setAccessibleName("Apostador /n Monto Jugada / Monto Jugada Feliz / Monto Retenido Todos Ponen");

        org.jdesktop.layout.GroupLayout jPanel2Layout = new org.jdesktop.layout.GroupLayout(jPanel2);
        jPanel2.setLayout(jPanel2Layout);
        jPanel2Layout.setHorizontalGroup(
            jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(org.jdesktop.layout.GroupLayout.TRAILING, jPanel2Layout.createSequentialGroup()
                .addContainerGap()
                .add(jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING)
                    .add(org.jdesktop.layout.GroupLayout.LEADING, jLabel4)
                    .add(org.jdesktop.layout.GroupLayout.LEADING, jLabel5)
                    .add(org.jdesktop.layout.GroupLayout.LEADING, jTextResultado, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 54, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(org.jdesktop.layout.GroupLayout.LEADING, jTextTiradorUltimoTiro, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 119, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .add(1943, 1943, 1943))
            .add(jPanel2Layout.createSequentialGroup()
                .addContainerGap()
                .add(jPanel6, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(1878, Short.MAX_VALUE))
        );
        jPanel2Layout.setVerticalGroup(
            jPanel2Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jPanel2Layout.createSequentialGroup()
                .add(jLabel4)
                .add(5, 5, 5)
                .add(jTextTiradorUltimoTiro, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(jLabel5)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(jTextResultado, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(jPanel6, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addContainerGap())
        );

        jPanel1.setBorder(javax.swing.BorderFactory.createTitledBorder("Proximo Tiro"));
        jPanel1.setName("jPanel1"); // NOI18N

        jLabel2.setText("Tiro salida");
        jLabel2.setName("jLabel2"); // NOI18N

        jRadioSalidaSi.setText("Si");
        jRadioSalidaSi.setEnabled(false);
        jRadioSalidaSi.setName("jRadioSalidaSi"); // NOI18N
        jRadioSalidaSi.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jRadioSalidaSiActionPerformed(evt);
            }
        });

        jRadioSalidaNo.setText("No");
        jRadioSalidaNo.setEnabled(false);
        jRadioSalidaNo.setName("jRadioSalidaNo"); // NOI18N

        jLabel1.setText("Tirador");
        jLabel1.setName("jLabel1"); // NOI18N

        jTextTiradorProximoTiro.setEditable(false);
        jTextTiradorProximoTiro.setName("jTextTiradorProximoTiro"); // NOI18N

        jTextPunto.setEditable(false);
        jTextPunto.setName("jTextPunto"); // NOI18N

        jLabel3.setText("Punto");
        jLabel3.setName("jLabel3"); // NOI18N

        org.jdesktop.layout.GroupLayout jPanel1Layout = new org.jdesktop.layout.GroupLayout(jPanel1);
        jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(
            jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jPanel1Layout.createSequentialGroup()
                .addContainerGap()
                .add(jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(jTextTiradorProximoTiro, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 154, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel1)
                    .add(jLabel2)
                    .add(jPanel1Layout.createSequentialGroup()
                        .add(jRadioSalidaSi)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                        .add(jRadioSalidaNo))
                    .add(jTextPunto, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 51, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel3))
                .addContainerGap(17, Short.MAX_VALUE))
        );
        jPanel1Layout.setVerticalGroup(
            jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jPanel1Layout.createSequentialGroup()
                .add(jLabel1)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(jTextTiradorProximoTiro, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .add(28, 28, 28)
                .add(jLabel2)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(jPanel1Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jRadioSalidaSi)
                    .add(jRadioSalidaNo))
                .add(13, 13, 13)
                .add(jLabel3)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(jTextPunto, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(35, Short.MAX_VALUE))
        );

        jPanel3.setBorder(javax.swing.BorderFactory.createTitledBorder("Apuestas Vigentes"));
        jPanel3.setName("jPanel3"); // NOI18N

        jScrollPane2.setName("jScrollPane2"); // NOI18N

        jListApuestas.setName("jListApuestas"); // NOI18N
        jScrollPane2.setViewportView(jListApuestas);

        jLabel7.setText("Jugador/Tipo/Puntaje/Fichas");
        jLabel7.setName("jLabel7"); // NOI18N

        org.jdesktop.layout.GroupLayout jPanel3Layout = new org.jdesktop.layout.GroupLayout(jPanel3);
        jPanel3.setLayout(jPanel3Layout);
        jPanel3Layout.setHorizontalGroup(
            jPanel3Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jPanel3Layout.createSequentialGroup()
                .addContainerGap()
                .add(jPanel3Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(jScrollPane2, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 170, Short.MAX_VALUE)
                    .add(jLabel7))
                .addContainerGap())
        );
        jPanel3Layout.setVerticalGroup(
            jPanel3Layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(jPanel3Layout.createSequentialGroup()
                .add(jLabel7)
                .add(9, 9, 9)
                .add(jScrollPane2, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 256, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        jButton1.setText("Actualizar Estado");
        jButton1.setName("jButton1"); // NOI18N
        jButton1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton1ActionPerformed(evt);
            }
        });

        org.jdesktop.layout.GroupLayout layout = new org.jdesktop.layout.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(layout.createSequentialGroup()
                .addContainerGap()
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(jPanel5, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jPanel1, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(jPanel2, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 229, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(layout.createSequentialGroup()
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                        .add(jPanel3, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                    .add(layout.createSequentialGroup()
                        .add(67, 67, 67)
                        .add(jButton1)))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(org.jdesktop.layout.GroupLayout.TRAILING, layout.createSequentialGroup()
                .addContainerGap()
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING)
                    .add(org.jdesktop.layout.GroupLayout.LEADING, jPanel2, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .add(org.jdesktop.layout.GroupLayout.LEADING, layout.createSequentialGroup()
                        .add(jPanel5, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(jPanel1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                    .add(org.jdesktop.layout.GroupLayout.LEADING, layout.createSequentialGroup()
                        .add(jPanel3, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                        .add(34, 34, 34)
                        .add(jButton1)))
                .addContainerGap())
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

private void jRadioSalidaSiActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jRadioSalidaSiActionPerformed
// TODO add your handling code here:
}//GEN-LAST:event_jRadioSalidaSiActionPerformed

private void jButton1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton1ActionPerformed
    this.readState();
}//GEN-LAST:event_jButton1ActionPerformed

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton jButton1;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel10;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JLabel jLabel5;
    private javax.swing.JLabel jLabel6;
    private javax.swing.JLabel jLabel7;
    private javax.swing.JLabel jLabel8;
    private javax.swing.JLabel jLabel9;
    private javax.swing.JList jListApuestas;
    private javax.swing.JList jListJugadores;
    private javax.swing.JList jListPremios;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JPanel jPanel2;
    private javax.swing.JPanel jPanel3;
    private javax.swing.JPanel jPanel5;
    private javax.swing.JPanel jPanel6;
    private javax.swing.JRadioButton jRadioSalidaNo;
    private javax.swing.JRadioButton jRadioSalidaSi;
    private javax.swing.JScrollPane jScrollJugadores1;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JTextField jTextPunto;
    private javax.swing.JTextField jTextResultado;
    private javax.swing.JTextField jTextTiradorProximoTiro;
    private javax.swing.JTextField jTextTiradorUltimoTiro;
    // End of variables declaration//GEN-END:variables


}
