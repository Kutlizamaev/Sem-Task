using CarFleet.DAL.Entities;
using MailKit.Net.Smtp;
using MimeKit;

namespace CarFleet.BLL.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string id)
        {
            try
            {
                var message = new MimeMessage();

                message.From.Add(new MailboxAddress("Admin CarFleet", "carfleetadm@mail.ru"));
                message.To.Add(new MailboxAddress("", email));
                message.Subject = "Confirm your account";
                message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = $"Подтвердите регистрацию, перейдя по ссылке: <a href='http://localhost:5000/api/account/confirmemail?userId={id}'>Confirm</a>"
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.mail.ru", 465, true);
                    await client.AuthenticateAsync("carfleetadm@mail.ru", "SMk4VBZ2HdSeSqr0YXT7");
                    await client.SendAsync(message);

                    await client.DisconnectAsync(true);
                }
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message + $"[{nameof(EmailService)}:{nameof(SendEmailAsync)}]");
            }
        }
    }
}
