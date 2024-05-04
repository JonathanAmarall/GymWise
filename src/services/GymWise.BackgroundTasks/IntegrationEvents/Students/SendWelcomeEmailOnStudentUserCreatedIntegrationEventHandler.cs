using GymWise.Api.Models;
using GymWise.Core.Contracts.Messaging;
using GymWise.Core.Contracts.Notifications;
using GymWise.Core.Errors;
using GymWise.Core.Exceptions;
using GymWise.Core.Models.Email;
using GymWise.Core.Models.Events.IntegrationEvents;
using Microsoft.AspNetCore.Identity;

namespace GymWise.BackgroundTasks.IntegrationEvents.Students
{
    internal sealed class SendWelcomeEmailOnStudentUserCreatedIntegrationEventHandler : IIntegrationEventHandler<NewStudentUserCreatedIntegrationEvent>
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailNotificationService _emailNotificationService;

        public SendWelcomeEmailOnStudentUserCreatedIntegrationEventHandler(UserManager<User> userManager, IEmailNotificationService emailNotificationService)
        {
            _userManager = userManager;
            _emailNotificationService = emailNotificationService;
        }

        public async Task Handle(NewStudentUserCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            DomainException.ThrowIfNull(notification, DomainErrors.Student.NotFound);

            var user = await _userManager.FindByIdAsync(notification.Id.ToString()) ?? throw new DomainException(DomainErrors.Student.NotFound);

            var welcomeToFirstAccessEmail = new WelcomeToFirstAccessEmail(user.Email!, notification.FirstName, notification.TemporaryPassword);

            await _emailNotificationService.SendWelcomeToFirstAccessEmail(welcomeToFirstAccessEmail);
        }
    }
}
