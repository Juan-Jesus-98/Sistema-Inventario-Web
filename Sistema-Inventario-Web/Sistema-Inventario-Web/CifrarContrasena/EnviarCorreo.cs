using System;
using System.Net.Mail;
using System.Web;

namespace Sistema_Inventario_Web.CifrarContrasena
{
    public class EnviarCorreo
    {
        public static bool EnviarMail(string correo, string titulo, string mensaje)
        {
            var resultado = false;
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(correo);
                mail.From = new MailAddress("juanjesus.19982412@gmail.com");
                mail.Subject = titulo;
                mail.Body = mensaje;
                mail.IsBodyHtml = true;

                var smtp = new SmtpClient()
                {
                    Credentials = new System.Net.NetworkCredential("juanjesus.19982412@gmail.com", "diosesamor199824"),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true
                };
                smtp.Send(mail);
                resultado = true;
            }
            catch (Exception e)
            {
                resultado = false;
            }
            return resultado;

        }
        public static string UrlOriginal(HttpRequestBase request)
        {
            string hostHeader = request.Headers["host"];
            //string.Format("{0}://{1}{2}",
            //   request.Url.Scheme,
            //   hostHeader,
            //   request.RawUrl);
            return string.Format("{0}://{1}",
               request.Url.Scheme,
               hostHeader);
        }
    }
}
