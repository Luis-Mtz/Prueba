using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;

namespace FillTheGap.Contacto.Business.Utility
{
    public class UtiCorreo
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direccionAQuienSeManda"></param>
        /// <param name="tituloCorreo"></param>
        /// <param name="cuerpoCorreo"></param>
        public void MandarCorreo(string direccionAQuienSeManda, string tituloCorreo, string cuerpoCorreo)
        {
            try
            {
                MailMessage mensaje = new MailMessage();

                string direccionQuienManda = ConfigurationManager.AppSettings["direccionQuienManda"];

                mensaje.From = new MailAddress(direccionQuienManda); //Aquí puede ir cualquier correo electrónico
                mensaje.To.Add(new MailAddress(direccionAQuienSeManda));
                mensaje.Subject = tituloCorreo;
                mensaje.Body = cuerpoCorreo;
                //Attachment at = new Attachment("Imagenes/espera_hotmail2.gif");
                //mensaje.Attachments.Add(at);

                mensaje.Priority = MailPriority.Normal;
                SmtpClient smtl = new SmtpClient();
                smtl.Host = UtiCrypto.DesEncriptar( ConfigurationManager.AppSettings["smtp.Host"]);       //"mail.tag-tic.com.mx";
                smtl.Port = Convert.ToInt32(UtiCrypto.DesEncriptar(ConfigurationManager.AppSettings["smtp.Port"]));  //26;
                string usuario =ConfigurationManager.AppSettings["usuario"];
                string contraseña = ConfigurationManager.AppSettings["contraseña"];
                smtl.Credentials = new System.Net.NetworkCredential( UtiCrypto.DesEncriptar(usuario),  UtiCrypto.DesEncriptar(contraseña)); //new System.Net.NetworkCredential("fill@tag-tic.com.mx", "fill");
                smtl.Send(mensaje);
            }
            catch (Exception ex)
            {
                ApplicationException a = new ApplicationException("No se mando el correo electrónico",ex);
                a.Data.Add("1", "DejarPasar");
                //throw a;
            }
        }

    }
}
