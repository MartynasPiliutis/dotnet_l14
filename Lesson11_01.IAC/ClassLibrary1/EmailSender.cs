using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace IAC.BL
{
    public class EmailSender
    {
        public bool SendEmail(string message)
        {
            var client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("jusu_mailtrap_vardas", "jusu_mailtrap_pastas"),
                EnableSsl = true
            };

            var msg = new MailMessage(
                "from@gmail.com",
                "to@gmail.com", 
                "HTML Report",
                message);

            msg.IsBodyHtml = true;

            client.Send(msg);

            return true;
        }
    }
}
