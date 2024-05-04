using GymWise.Core.Contracts.Notifications;
using GymWise.Core.Models.Email;
using GymWise.Core.Services.Email;
using GymWise.Core.Services.Email.Request;

namespace GymWise.Core.Services.Notifications
{
    public class EmailNotificationService : IEmailNotificationService
    {
        private readonly IEmailService _emailService;

        public EmailNotificationService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task SendWelcomeToFirstAccessEmail(WelcomeToFirstAccessEmail welcomeToFirstAccessEmail)
        {
            var mailRequest = new MailRequest(
                welcomeToFirstAccessEmail.EmailTo,
                $"Bem-vindo ao GymWise! 🎉",
                $"Bem-vindo ao GymWise {welcomeToFirstAccessEmail.Name}," +
                Environment.NewLine +
                $"Seu email de acesso é: {welcomeToFirstAccessEmail.EmailTo}" +
                Environment.NewLine +
                $"Sua senha temporária é: {welcomeToFirstAccessEmail.TemporaryPassword}" +
                Environment.NewLine +
                "Sugerimos fortemente que alterer esta senha em seu primeiro acesso.");

            await _emailService.SendEmailAsync(mailRequest);
        }
    }
}
