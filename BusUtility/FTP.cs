using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
//using System.Net.FtpWebRequest;
using System.Net;
using System.Net;
using System.IO;
using System.Linq;

namespace CFDINVOICE
{
    //•archivo: Ruta local del archivo
    //•destino: Dirección FTP del destino del archivo. Ej: "ftp://direccion_de_ejemplo/directorio/archivo.txt"
    //•dir: Dirección FTP del directorio donde se almacena / almacenará el archivo. Ej: "ftp://direccion_de_ejemplo/directorio"

    class FTP
    {
        string host;
        string user;
        string pass;
        //host = "ftp.direccion_de_ejemplo.com"
        //user = "userp@direccion_de_ejemplo.com"
        //pass = "Pasword"

        public FTP(string host, string user, string pass)
        {
            this.host = host;
            this.user = user;
            this.pass = pass;

        }

        public string eliminarArchivo(string Archivo)
        {
            //objFTP.eliminarFichero("ftp://ftp.ftp.com/EDGAR/Copy of 12345_Factura123456.pdf")
            FtpWebRequest peticionFTP = default(FtpWebRequest);

            // Creamos una petición FTP con la dirección del Archivo a eliminar
            peticionFTP = (FtpWebRequest)WebRequest.Create(new Uri(Archivo));

            // Fijamos el usuario y la contraseña de la petición
            peticionFTP.Credentials = new NetworkCredential(user, pass);

            // Seleccionamos el comando que vamos a utilizar: Eliminar un Archivo
            peticionFTP.Method = WebRequestMethods.Ftp.DeleteFile;
            peticionFTP.UsePassive = false;

            try
            {
                FtpWebResponse respuestaFTP = default(FtpWebResponse);
                respuestaFTP = (FtpWebResponse)peticionFTP.GetResponse();
                respuestaFTP.Close();
                // Si todo ha ido bien, devolvemos String.Empty
                return string.Empty;
            }
            catch (Exception ex)
            {
                // Si se produce algún fallo, se devolverá el mensaje del error
                return ex.Message;
            }
        }


        public bool existeObjeto(string dir)
        {
            //If objFTP.existeObjeto("ftp://ftp.ftp.com/EDGAR/Copy of 12345_Factura123456.pdf") = True Then
            //    MsgBox("el archivo existe")
            //Else
            //    MsgBox("el archino no existe")
            //End If
            FtpWebRequest peticionFTP = default(FtpWebRequest);

            // Creamos una peticion FTP con la dirección del objeto que queremos saber si existe
            peticionFTP = (FtpWebRequest)WebRequest.Create(new Uri(dir));

            // Fijamos el usuario y la contraseña de la petición
            peticionFTP.Credentials = new NetworkCredential(user, pass);

            // Para saber si el objeto existe, solicitamos la fecha de creación del mismo
            peticionFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp;

            peticionFTP.UsePassive = false;

            try
            {
                // Si el objeto existe, se devolverá True
                FtpWebResponse respuestaFTP = default(FtpWebResponse);
                respuestaFTP = (FtpWebResponse)peticionFTP.GetResponse();
                return true;
            }
            catch (Exception ex)
            {
                // Si el objeto no existe, se producirá un error y al entrar por el Catch
                // se devolverá falso
                return false;
            }
        }


        public string creaDirectorio(string dir)
        {
            FtpWebRequest peticionFTP = default(FtpWebRequest);

            // Creamos una peticion FTP con la dirección del directorio que queremos crear
            peticionFTP = (FtpWebRequest)WebRequest.Create(new Uri(dir));

            // Fijamos el usuario y la contraseña de la petición
            peticionFTP.Credentials = new NetworkCredential(user, pass);

            // Seleccionamos el comando que vamos a utilizar: Crear un directorio
            peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory;

            try
            {
                FtpWebResponse respuesta = default(FtpWebResponse);
                respuesta = (FtpWebResponse)peticionFTP.GetResponse();
                respuesta.Close();
                // Si todo ha ido bien, se devolverá String.Empty
                return string.Empty;
            }
            catch (Exception ex)
            {
                // Si se produce algún fallo, se devolverá el mensaje del error
                return ex.Message;
            }
        }


        public string subirArchivo(string Archivo, string destino, string dir)
        {
            //objFTP.subirFichero("C:\ArchivosTest\Copy of 12345_Factura123456.pdf", "ftp://ftp.ftp.com/EDGAR/Copy of 12345_Factura123456.pdf", "ftp://ftp.ftp.com/EDGAR")
            FileInfo infoArchivo = new FileInfo(Archivo);

            string uri = null;
            uri = destino;

            // Si no existe el directorio, lo creamos
            if (!existeObjeto(dir))
            {
                creaDirectorio(dir);
            }

            FtpWebRequest peticionFTP = default(FtpWebRequest);

            // Creamos una peticion FTP con la dirección del Archivo que vamos a subir
            peticionFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(destino));

            // Fijamos el usuario y la contraseña de la petición
            peticionFTP.Credentials = new NetworkCredential(user, pass);

            peticionFTP.KeepAlive = false;
            peticionFTP.UsePassive = false;

            // Seleccionamos el comando que vamos a utilizar: Subir un Archivo
            peticionFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // Especificamos el tipo de transferencia de datos
            peticionFTP.UseBinary = true;

            // Informamos al servidor sobre el tamaño del Archivo que vamos a subir
            peticionFTP.ContentLength = infoArchivo.Length;

            // Fijamos un buffer de 2KB
            int longitudBuffer = 0;
            longitudBuffer = 2048;
            byte[] lector = new byte[2049];

            int num = 0;

            // Abrimos el Archivo para subirlo
            FileStream fs = default(FileStream);
            fs = infoArchivo.OpenRead();

            try
            {
                Stream escritor = default(Stream);
                escritor = peticionFTP.GetRequestStream();

                // Leemos 2 KB del Archivo en cada iteración
                num = fs.Read(lector, 0, longitudBuffer);

                while ((num != 0))
                {
                    // Escribimos el contenido del flujo de lectura en el 
                    // flujo de escritura del comando FTP
                    escritor.Write(lector, 0, num);
                    num = fs.Read(lector, 0, longitudBuffer);
                }

                escritor.Close();
                fs.Close();
                escritor.Dispose();
                fs.Dispose();

                // Si todo ha ido bien, se devolverá String.Empty
                return string.Empty;
            }
            catch (Exception ex)
            {
                // Si se produce algún fallo, se devolverá el mensaje del error
                return ex.Message;
            }
        }


        public string bajaArchivo(string dir, string Archivo)
        {
            //objFTP.bajaArchivo("ftp://ftp.com/XRP_Rep/Copy of 12345_Factura123456.pdf", "C:\ArchivosTestDestino")
            FtpWebRequest peticionFTP = default(FtpWebRequest);

            // Creamos una peticion FTP con la dirección del directorio que queremos descargar
            peticionFTP = (FtpWebRequest)WebRequest.Create(new Uri(dir));

            // Fijamos el usuario y la contraseña de la petición
            peticionFTP.Credentials = new NetworkCredential(user, pass);

            // Le digo que no mantenga la conexión activa al terminar.
            peticionFTP.KeepAlive = false;

            // Seleccionamos el comando que vamos a utilizar: Crear un directorio
            peticionFTP.Method = WebRequestMethods.Ftp.DownloadFile;

            // Especificamos el tipo de transferencia de datos
            peticionFTP.UseBinary = true;

            // Desactivo cualquier posible proxy http.
            // Ojo pues de saltar este paso podría usar 
            // un proxy configurado en iexplorer
            peticionFTP.Proxy = null;

            // Activar si se dispone de SSL
            peticionFTP.EnableSsl = false;

            // Configuro el buffer a 2 KBytes
            int buffLength = 2048;
            byte[] buffer = new byte[buffLength + 1];
            int contentLen = 0;

            Archivo = Path.Combine(Archivo, Path.GetFileName(dir));

            try
            {

                FileStream fs = new FileStream(Archivo, FileMode.Create, FileAccess.Write, FileShare.None);

                Stream strm = default(Stream);
                //    responseStream = respuesta.GetResponseStream()
                strm = peticionFTP.GetResponse().GetResponseStream();

                contentLen = strm.Read(buffer, 0, buffLength);

                while ((contentLen != null))
                {
                    fs.Write(buffer, 0, contentLen);
                    contentLen = strm.Read(buffer, 0, buffLength);
                }
                strm.Close();
                fs.Close();
                fs.Dispose();
                strm.Dispose();
                // Si todo ha ido bien, se devolverá String.Empty
                return string.Empty;
            }
            catch (Exception ex)
            {
                // Si se produce algún fallo, se devolverá el mensaje del error
                return ex.Message;
            }


        }


        public object enlistaArchivos(string dir)
		{
			//'Enlista
			//Dim found As Boolean = False
			//Dim thisCollection As New Collection
			//'For Each thisObject As String In objFTP.enlistaArchivos("ftp://ftp.ftp.com/EDGAR/") 'thisCollection
			//For Each thisObject As String In objFTP.enlistaArchivos("ftp://ftp.com/XRP_Rep/") 'thisCollection
			// 'For Each foundFile As String In My.Computer.FileSystem.GetFiles(sTransition)
			//    If thisObject.ToString.EndsWith(".pdf") = True Then
			//        'found = True
			//        MsgBox("hay pdf y se llama: " & thisObject)
			//        'Exit For
			//    End If
			//Next thisObject
			FtpWebRequest peticionFTP = default(FtpWebRequest);

			// Creamos una peticion FTP con la dirección del directorio que queremos enlistar
			peticionFTP = (FtpWebRequest)WebRequest.Create(new Uri(dir));

			// Fijamos el usuario y la contraseña de la petición
			peticionFTP.Credentials = new NetworkCredential(user, pass);

			// Seleccionamos el comando que vamos a utilizar: enlistar archivos
			//peticionFTP.Method = WebRequestMethods.Ftp.ListDirectory 'Me muestra tambien las carpetas
			peticionFTP.Method = WebRequestMethods.Ftp.ListDirectory;


			StreamReader sr = new StreamReader(peticionFTP.GetResponse().GetResponseStream());

			ArrayList strLista = new ArrayList();
			//Dim str As String=sr.ReadLine()
			string str = null;
			str = sr.ReadLine();

			while ((str != null)) {
				strLista.Add(str);
				str = sr.ReadLine();
			}
			sr.Close();
			sr = null;
			return strLista;
		}
	}
}

    