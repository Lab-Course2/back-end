﻿using MailKit.Net.Smtp;
using MimeKit;
using MindMuse.Application.Contracts.Interfaces;
using MindMuse.Application.Contracts.Models.EmailConfig;

namespace MindMuse.Application.Services
{
    public class EmailService : IEmailServices
    {
        private readonly EmailConfiguration _emailConfiguration;

        public EmailService(EmailConfiguration emailConfiguration)
        {
            this._emailConfiguration = emailConfiguration;
        }
        public async Task SendEmail(Messages messages)
        {
            var emailMessage = CreateEmailMessage(messages);
            await SendAsync(emailMessage);

        }
        private MimeMessage CreateEmailMessage(Messages messages)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("MindMuse System", _emailConfiguration.From));
            mimeMessage.To.AddRange(messages.To);
            mimeMessage.Subject = messages.Subject;
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = messages.Content;

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            return mimeMessage;

        }
        private async Task SendAsync(MimeMessage message)
        {
            using var client = new SmtpClient();

            try
            {
                client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.Port, MailKit.Security.SecureSocketOptions.StartTls);

                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate(_emailConfiguration.Username, _emailConfiguration.Password);


                client.Send(message);



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

                client.Disconnect(true);
                client.Dispose();

            }

        }
    }
}