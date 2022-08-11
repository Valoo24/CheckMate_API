using CheckMate_API.Exceptions;
using System.Net;
using System.Net.Mail;

namespace CheckMate_API.Tools
{
    public static class MailManager
    {
        public static void SendFromKhunly(string receiverMailAdress, string content, string title)
        {
            string sender = "net2022@khunly.be";
            string pasword = "test1234=";

            MailMessage message = new MailMessage();
            message.To.Add(receiverMailAdress);
            message.From = new MailAddress(sender);
            message.Body = content;
            message.Subject = title ;

            SmtpClient smtp = new SmtpClient("SSL0.ovh.net");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(sender, pasword);

            try
            {
                smtp.Send(message);
            }
            catch(Exception e)
            {
                throw new MailNotSentExceptions(e.Message);
            }
        }
    }
}
