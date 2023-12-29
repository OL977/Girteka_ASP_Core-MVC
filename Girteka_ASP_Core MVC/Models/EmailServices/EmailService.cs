using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Girteka_ASP_Core_MVC.Models.EmailServices
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string massage)
        {
            var emailmessage = new MimeMessage();

            emailmessage.From.Add(new MailboxAddress("Администрация сайта", "alehshel.girteka@gmail.com"));
            emailmessage.To.Add(new MailboxAddress("", email));
            emailmessage.Subject = subject;
            emailmessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = massage
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync("alehshel.girteka@gmail.com", "sZ4HAKjyMTS2");
                await client.SendAsync(emailmessage);

                await client.DisconnectAsync(true);

            }
        }

    }
}
