using Microsoft.Extensions.Configuration;
using PreferenceRobot.Application.Interfaces.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Infrastructure.Services.Mail
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string to, string subject, string body, bool bodyHtml = true)
        {
            await SendMailAsync(new[] { to }, subject, body, bodyHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool bodyHtml = true)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = bodyHtml;
            foreach (var to in tos)
            {
                mailMessage.To.Add(to);
            }
            mailMessage.From = new(_configuration["Mail:Username"], _configuration["Mail:Password"],Encoding.UTF8);

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
            smtpClient.Host = _configuration["Mail:Host"];
            smtpClient.Port = Convert.ToInt32(_configuration["Mail:Port"]);
            smtpClient.EnableSsl = true;
            await smtpClient.SendMailAsync(mailMessage);


        }

        public async Task SendPasswordResetMailAsync(string to, string userId, string resetToken)
        {
            //Genel yapılandırması webe göre hazırlandı çünkü normalde bir web sitesinden işlem gerçekleştirileceği için
            //o yüzden sadece mailin doğru gelmesi ve user ıd token yapısının çalımasına bakılcak
            StringBuilder mail = new();
            mail.AppendLine("Merhaba<br>Eğer yeni şifre talebinde bulunduysanız aşağıdaki linkten şifrenizi yenileyebilirsiniz.<br><strong><a target=\"_blank\" href=\"");
            mail.AppendLine(_configuration["ClientUrl"]);
            mail.AppendLine("/update-password/");
            mail.AppendLine(userId);
            mail.AppendLine("/");
            mail.AppendLine(resetToken);
            mail.AppendLine("\">Yeni şifre talebi için tıklayınız...</a></strong><br><br><span style=\"font-size:12px;\">NOT : Eğer ki bu talep tarafınızca gerçekleştirilmemişse lütfen bu maili ciddiye almayınız.</span><br>Saygılarımızla...");

            await SendMailAsync(to, "Şifre Yenileme Talebi", mail.ToString());
        }
    }
}
