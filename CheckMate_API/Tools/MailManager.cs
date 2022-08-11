﻿using System.Net;
using System.Net.Mail;

namespace CheckMate_API.Tools
{
    public static class MailManager
    {
        public static bool SendFromKhunly(string receiverMailAdress, string content)
        {
            string sender = "net2022@khunly.be";
            string pasword = "test1234=";

            MailMessage message = new MailMessage();
            message.To.Add(receiverMailAdress);
            message.From = new MailAddress(sender);
            message.Body = content;
            message.Subject = "Ceci est un test de moi à moi";

            SmtpClient smtp = new SmtpClient("SSL0.ovh.net");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(sender, pasword);

            try
            {
                smtp.Send(message);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
