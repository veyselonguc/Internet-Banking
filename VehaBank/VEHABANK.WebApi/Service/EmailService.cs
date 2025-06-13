using MailKit.Net.Smtp;
using MimeKit;

namespace VEHABANK.WebApi.Service
{
    public interface IEmailService
    {
        Task SendVerificationCodeAsync(string toEmail, string code,string nameSurname);
        Task SendVerificationCodeAsync(string toEmail, string code, bool isAuthenticate, string employeePassword);
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendVerificationCodeAsync(string toEmail, string code,string nameSurname)
        {

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_config["EmailSettings:SenderName"], _config["EmailSettings:From"])); // Gönderen adı olarak kod
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = "VEHA Bank Doğrulama Kodu";

            var webUIPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())!.FullName, "VEHABANK.WebUI", "EmailVerify", "VerificationEmailTemplate.html");

            if (!File.Exists(webUIPath))
                throw new FileNotFoundException("Şablon dosyası bulunamadı: " + webUIPath);

            var htmlBody = await File.ReadAllTextAsync(webUIPath);


            // Dosyanın varlığını kontrol et
            if (!File.Exists(webUIPath))
            {
                throw new FileNotFoundException($"Şablon dosyası bulunamadı: {webUIPath}");
            }

            // HTML şablonunu oku
            string htmlTemplate = await File.ReadAllTextAsync(webUIPath);

            // Kod yerine koy
            string emailBody = htmlTemplate.Replace("{{CODE}}", code).Replace("{{NAMESURNAME}}", nameSurname);

            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = emailBody
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_config["EmailSettings:SmtpServer"], 587, false);
            await smtp.AuthenticateAsync(_config["EmailSettings:From"], _config["EmailSettings:Password"]);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }




        //------------------------------------------------------------------------------------------------
        public async Task SendVerificationCodeAsync(string toEmail, string code,bool isAuthenticate=true,string employeePassword="")
        {
            var subject="";
            var emailTemplate = "";
            if (isAuthenticate)
            {
                subject = "VEHA Bank Doğrulama Kodu";
                emailTemplate = "VerificationEmailTemplate.html";
            }
            else
            {
                subject = "VEHA Bank Personel Bilgilendirme";
                emailTemplate = "EmployeeEmailTemplate.html";
            }
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config["EmailSettings:From"]));
            //email.ResentSender = new MailboxAddress("VEHA-Bank", _config["EmailSettings:From"]); // Gönderen adı
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;

            var webUIPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())!.FullName, "VEHABANK.WebUI", "EmailVerify",emailTemplate);

            if (!File.Exists(webUIPath))
                throw new FileNotFoundException("Şablon dosyası bulunamadı: " + webUIPath);

            var htmlBody = await File.ReadAllTextAsync(webUIPath);


            // Dosyanın varlığını kontrol et
            if (!File.Exists(webUIPath))
            {
                throw new FileNotFoundException($"Şablon dosyası bulunamadı: {webUIPath}");
            }

            // HTML şablonunu oku
            string htmlTemplate = await File.ReadAllTextAsync(webUIPath);


            // Kod yerine koy
            string emailBody = htmlTemplate.Replace("{{CODE}}", code).Replace("{{EMAIL}}", toEmail).Replace("{{PASSWORD}}", employeePassword);

            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = emailBody
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_config["EmailSettings:SmtpServer"], 587, false);
            await smtp.AuthenticateAsync(_config["EmailSettings:From"], _config["EmailSettings:Password"]);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

    }

}
