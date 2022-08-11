using CheckMate_BLL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_BLL.Tools
{
    /// <summary>
    /// Objet Statique permettant l'envoi d'Email.
    /// </summary>
    public static class MailManager
    {
        /// <summary>
        /// Permet d'envoyer un email depuis le serveur OVH du formateur ( KhunLy - mercy ;-) )
        /// </summary>
        /// <param name="receiverMailAdress">Adresse email du destinataire.</param>
        /// <param name="content">Contenu de l'email.</param>
        /// <param name="title">Sujet de l'email</param>
        /// <exception cref="MailNotSentExceptions">Exception levée si l'email ne s'est pas envoyé correctement.</exception>
        public static void SendFromKhunly(string receiverMailAdress, string content, string title)
        {
            string sender = "net2022@khunly.be";
            string pasword = "test1234=";

            MailMessage message = new MailMessage();
            message.To.Add(receiverMailAdress);
            message.From = new MailAddress(sender);
            message.Body = content;
            message.Subject = title;

            SmtpClient smtp = new SmtpClient("SSL0.ovh.net");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(sender, pasword);

            try
            {
                smtp.Send(message);
            }
            catch (Exception e)
            {
                throw new MailNotSentExceptions(e.Message);
            }
        }
    }
}