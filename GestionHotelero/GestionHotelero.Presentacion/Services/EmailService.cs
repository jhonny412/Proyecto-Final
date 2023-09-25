using GestionHotelero.Entities.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace GestionHotelero.Presentacion.Services
{
    public class EmailService : IEmailSender
    {
        private readonly SmtpConfiguration _smtp;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<AppConfig> options, ILogger<EmailService> logger)
        {
            _smtp = options.Value.SmtpConfiguration;
            _logger = logger;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                var mailMessage = new MailMessage(new MailAddress(_smtp.UserName, _smtp.FromName), new MailAddress(email));

                mailMessage.Subject = subject;
                mailMessage.Body = htmlMessage;
                mailMessage.IsBodyHtml = true;

                using (var smtpClient = new SmtpClient(_smtp.Server, _smtp.PortNumber))
                {
                    smtpClient.Credentials = new NetworkCredential(_smtp.UserName, _smtp.Password);
                    smtpClient.EnableSsl = _smtp.EnableSsl;

                    await smtpClient.SendMailAsync(mailMessage);
                    _logger.LogInformation("Envio de correo realizado con éxito a {email}", email);
                }
            }
            catch (SmtpException ex)
            {
                _logger.LogWarning("No se puede enviar el correo {message}", ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Error al enviar el correo {email} {message}", email, ex.Message);
            }
        }
    }
}