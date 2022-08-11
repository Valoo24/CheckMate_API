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
        /// Permet l'envoi d'Email depuis le serveur OVH du formateur ( Khun Ly - Merci ;-) ).
        /// </summary>
        /// <param name="receiverMailAdress">Adresse Email du destinataire</param>
        /// <param name="content">Contenu de l'email.</param>
        /// <param name="Title">Sujet de l'Email</param>
        /// <returns>Renvoie True si l'Email s'est bien envoyé, False si il ne s'est pas envoyé correctement.</returns>
        public static bool SendFromKhunly(string receiverMailAdress, string content, string Title)
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
            catch (Exception e)
            {
                return false;
            }
        }
    }
}