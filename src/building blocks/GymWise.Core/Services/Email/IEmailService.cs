using GymWise.Core.Services.Email.Request;

namespace GymWise.Core.Services.Email;

public interface IEmailService
{
    Task SendEmailAsync(MailRequest mailRequest);
}
