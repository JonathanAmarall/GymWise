using GymWise.Core.Services.Email.Request;
using GymWise.Core.Services.Email.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace GymWise.Core.Services.Email;

public class EmailService : IEmailService
{
    private readonly MailSettings _mailSettings;
    public EmailService(IOptions<MailSettings> maiLSettingsOptions)
        => _mailSettings = maiLSettingsOptions.Value;

    public async Task SendEmailAsync(MailRequest mailRequest)
    {
        MimeMessage email = CreateMimeMessage(mailRequest);

        using var smtpClient = new SmtpClient();

        await smtpClient.ConnectAsync(
           _mailSettings.SmtpServer,
           _mailSettings.SmtpPort,
           SecureSocketOptions.StartTls);

        await smtpClient.AuthenticateAsync(_mailSettings.SenderEmail, _mailSettings.SmtpPassword);

        await smtpClient.SendAsync(email);

        await smtpClient.DisconnectAsync(true);
    }

    private MimeMessage CreateMimeMessage(MailRequest mailRequest)
    {
        return new MimeMessage
        {
            From =
                {
                    new MailboxAddress(_mailSettings.SenderDisplayName, _mailSettings.SenderEmail)
                },
            To =
                {
                    MailboxAddress.Parse(mailRequest.EmailTo)
                },
            Subject = mailRequest.Subject,
            Body = new TextPart(TextFormat.Text)
            {
                Text = mailRequest.Body
            }
        };
    }
}
