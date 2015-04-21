using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GP.Common
{
    public class MailUtility
    {
        public static void SendMail(string toEmail, string subject, string contentBody, AlternateView htmlView)
        {

            try
            {
                var mailPath = System.Configuration.ConfigurationManager.AppSettings["MailPath"];
                MailMessage message = new MailMessage();
                message.From = new MailAddress("tamannash@evolvingsols.com");
                message.To.Add(toEmail);
                message.Subject = subject;
                message.AlternateViews.Add(htmlView);
                message.Body = contentBody;
                message.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.EnableSsl = false;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                //logger.Log(ex, "SendMail()");
                throw ;
            }
        }
    }
}
