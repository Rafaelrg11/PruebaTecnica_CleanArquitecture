using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PruebaTécnica.Domain.Persons;

namespace PruebaTécnica.Application.Abstranctions.Identification
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;

        public EmailService(string smtpHost, int smtpPort, string smtpUser, string smtpPass)
        {
            _smtpClient = new SmtpClient(smtpHost)
            {
                Port = smtpPort,
                Credentials = new NetworkCredential(smtpUser, smtpPass),
                EnableSsl = true
            };
        }

        public async Task SendAsync(Domain.Persons.Name name, string subject, string body)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("no-reply@tudominio.com"), // Cambia por tu dirección de correo
                Subject = subject,
                Body = body,
                IsBodyHtml = true // Si el cuerpo del mensaje es HTML
            };

            mailMessage.To.Add(name.value);

            await _smtpClient.SendMailAsync(mailMessage);

            return;
        }
    }
}

