using GameShop.Data.Interfaces;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace GameShop.Data.Repository
{
    public class EmailOrderProcess : IOrderProcess
    {
        public void SendEmail(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("GameShop", "EMAIL")); // paste your email
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("Plain") { Text = message };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("EMAIL", "PASSWORD");   // paste your email account details
                client.Send(emailMessage);

                client.Disconnect(true);
            }
        }
    }
}
