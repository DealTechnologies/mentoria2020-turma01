using Locadora.Domain.Interfaces.Email;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Locadora.Domain.EmailConfs
{
    public class AuthMessageSender : IEmailSender
    {
        private readonly IOptions<EmailSettings> _options;

        public AuthMessageSender(IOptions<EmailSettings> emailSettings)
        {
            _options = emailSettings;
        }

        public Task EnviarEmailAsync(string email, string assunto, string mensagem)
        {
            try
            {
                Execute(email, assunto, mensagem).Wait();
                return Task.FromResult(0);
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task Execute(string email, string assunto, string mensagem)
        {
            try
            {
                string toEmail = string.IsNullOrEmpty(email) ? _options.Value.ToEmail : email;

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_options.Value.UsernameEmail, "Locadora")
                };

                mail.To.Add(new MailAddress(toEmail));
                mail.CC.Add(new MailAddress(_options.Value.CcEmail));

                mail.Subject = "Pedido Locadora - " + assunto;
                mail.Body = mensagem;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                // Outras Opções
                //mail.Attachments.Add(new Attachment(arquivo));
                //

                using (SmtpClient smtp = new SmtpClient(_options.Value.PrimaryDomain, _options.Value.PrimaryPort))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(_options.Value.UsernameEmail, _options.Value.UsernamePassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
