using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace CapaNegocio
{
    public class recuperacionCorreo
    {
        MailMessage m = new MailMessage();
        SmtpClient smtp = new SmtpClient();

        public bool enviarCorreo(string from,string contra, string to, string msj)
        {
            try
            {
                m.From = new MailAddress(from, "Inmobiliaria Inmmokraft LTDA.", System.Text.Encoding.UTF8);
                m.To.Add(new MailAddress(to));

                m.Body = msj;
                m.Subject = "Recuperar Contraseña..";
                smtp.Host = "smtp.gmail.com";

                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(from, contra);
                smtp.EnableSsl = true;
                smtp.Send(m);
                m.IsBodyHtml = true;

                return true;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

    }
}
