using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Diagnostics;


namespace DesfacaFacil.Models
{

    public class EmailCon

    {
        private SmtpClient MailClient;

        public EmailCon(string servidor, string usuario, string senha)
        {
            MailClient = new SmtpClient(servidor);
            MailClient.UseDefaultCredentials = false;
            NetworkCredential basicAuthenticationInfo = new
            NetworkCredential(usuario, senha);
            MailClient.Credentials = basicAuthenticationInfo;
        }

        public void enviarEmail(string remetente, string destinatario, string assunto, string mensagem)
        {
            Debug.WriteLine("Enviando Mensagem");
            MailMessage email = new MailMessage(remetente, destinatario);
            email.Subject = assunto;
            email.SubjectEncoding = Encoding.UTF8;
            email.Body = mensagem;
            email.BodyEncoding = Encoding.UTF8;
            email.IsBodyHtml = true;
            try
            {
                MailClient.Send(email);
            }
            catch (SmtpException ex)
            {
                Debug.WriteLine(ex.Message);
                throw new ApplicationException("Erro no envio:" + ex.Message);

            }

        }
    }
}