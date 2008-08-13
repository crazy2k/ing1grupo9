// Organizador.cs created with MonoDevelop
// User: tas at 12:01 12/08/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.IO;
using System.Collections.Generic;

namespace Organizador
{
	public class Organizador
	{
		
		private string[] dirs;
		
		public string[] Dirs {
			get {return dirs;}
			set {dirs = value;}
		}

		public Organizador()
		{
//			string a = Configuracion.DIRECTORIO_Escritura_Administracion;
//			string b = Configuracion.DIRECTORIO_Escritura_Jugadores;
			string c = Configuracion.DIRECTORIO_Escritura_Servidor;
			dirs = new string[] {c};
		}
				
		public void Organizar() {
			foreach (string dir in Dirs) {
				DirectoryInfo di = new DirectoryInfo(dir);
				FileInfo[] files = di.GetFiles("*.xml");
			
				foreach (FileInfo fi in files) {
					string mensaje = GetMensaje(fi);
/*					bool cond = false;
					try
					{
						cond = fi.Name.Substring(0, 22) == "respuestaEstadoCasino0";
					}
					catch (Exception ex){ }

					if (cond)
					{
						string final = fi.Name.Substring(23, fi.Name.Length - 23);
						string terminal = final.Split('.')[0].TrimStart(new char[] {'0'});
					Mover1:
						try
						{
							fi.MoveTo(di.FullName + "respuestaEstadoCasino" +
								Configuracion.Numero_Grupo.TrimStart(new char[] { '0' })
								+ terminal + ".xml");
						}
						catch (Exception e)
						{
							goto Mover1;
						}
					}
*/
					OrganizarMensaje(mensaje, fi);
					if (fi.Name.Substring(0,12) == "estadoCasino"){
						string final = fi.Name.Substring(12, fi.Name.Length - 12);
//						final = final.Split('.')[0];
//						string terminal = final.PadLeft(4,'0');
					Mover:
						try
						{
							fi.MoveTo(di.FullName + "pedidoEstadoCasino" + final);
//								Configuracion.Numero_Grupo + terminal + ".xml");
						}
						catch (Exception e)
						{
							goto Mover;
						}
					}
					
				}
			}
		}
		
		public string GetMensaje(FileInfo archivo) {
			string nombreArchivo = archivo.Name;
			
			string[] partes = nombreArchivo.Split(new char[] {'.'});
            string completo = partes[0];
            string mensaje = completo.Substring(0, completo.Length - 6);
			
			return mensaje;
		}

		public string GetTerminal(FileInfo archivo)
		{
			string nombreArchivo = archivo.Name;

			string[] partes = nombreArchivo.Split(new char[] { '.' });
			string completo = partes[0];
			string mensaje = completo.Substring(completo.Length - 4, 4);

			return mensaje;
		}
		
		public void OrganizarMensaje(string mensaje, FileInfo fi)
		{
/*			if (Configuracion.Mensajes_Lectura_Administracion.Contains(mensaje)
//				&& GetTerminal(fi) <= 10
				)
				fi.MoveTo(Configuracion.DIRECTORIO_Lectura_Administracion + fi.Name);
*/			
			//else 
			if (Configuracion.Mensajes_Lectura_Servidor.Contains(mensaje))
			{
			Mover:
				try
				{
					fi.MoveTo(Configuracion.DIRECTORIO_Lectura_Servidor + fi.Name);
				}
				catch (Exception e)
				{
					goto Mover;
				}
			}
			/*
			else if (Configuracion.Mensajes_Lectura_Jugadores.Contains(mensaje))
				fi.MoveTo(Configuracion.DIRECTORIO_Lectura_Jugadores + fi.Name);
			*/
		}
		
	}
}
