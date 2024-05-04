using GymWise.Core.Models.Email;

namespace GymWise.Core.Contracts.Notifications
{
    public interface IEmailNotificationService
    {
        Task SendWelcomeToFirstAccessEmail(WelcomeToFirstAccessEmail welcomeToFirstAccessEmail);
    }
}
