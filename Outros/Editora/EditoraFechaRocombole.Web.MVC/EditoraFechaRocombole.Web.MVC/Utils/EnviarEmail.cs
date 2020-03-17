using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Mail;

namespace EditoraFechaRocombole.Web.MVC.Utils
{
    public class EnviarEmail
    {
        SmtpClient smtpClient;
        MailAddress from;
        MailAddress to;
        MailMessage mailMessage;
        /// <summary>
        /// construtor da classe responsavel por enviar email
        /// </summary>
        /// <param name="mailFrom">e-mail de origem (remetente)</param>
        /// <param name="mailTo">e-mail destino</param>
        /// <param name="nameFrom">nome de quem envia</param>
        /// <param name="message">menssagem</param>
        /// <param name="subject">assunto</param>
        public EnviarEmail(string mailFrom,string mailTo, string nameFrom, string message, string subject)  //ctor tab tab cria construtor
        {
            //instanciar os objetos no momento da execuçao do costrutor

            //obejto que envia o emial
            smtpClient = new SmtpClient();

            //objetoc com emai lde origem
            from = new MailAddress(mailFrom, mailTo, System.Text.Encoding.UTF8);

            //objeto email de destino
            to = new MailAddress(mailTo);

            //mensagem completa com fro, to message
            mailMessage = new MailMessage(from, to);

            //menssagem
            mailMessage.Body = message;

            //assunto
            mailMessage.Subject = subject;
        }

        public void Send()
        {
            smtpClient.Host = "smtp.mail.yahoo.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;            
            smtpClient.UseDefaultCredentials = false;

            //credenciais de login no email
            var credenciais = new System.Net.NetworkCredential("flavio.lopess@yahoo.com.br","l@rissa360");
            smtpClient.Credentials = credenciais;
            //enviar o email
            smtpClient.Send(mailMessage);
            
        }
    }
}