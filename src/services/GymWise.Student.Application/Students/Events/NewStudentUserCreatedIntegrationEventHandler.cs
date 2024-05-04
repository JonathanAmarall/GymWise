using GymWise.Core.Contracts.Messaging;
using GymWise.Core.Contracts.Notifications;
using GymWise.Core.Exceptions;
using GymWise.Core.Models.Email;
using GymWise.Core.Models.Errors;
using GymWise.Core.Models.Events.IntegrationEvents;
using GymWise.Student.Domain.Repositories;

namespace GymWise.Student.Application.Students.Events
{
    internal sealed class NewStudentUserCreatedIntegrationEventHandler : IIntegrationEventHandler<NewStudentUserCreatedIntegrationEvent>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEmailNotificationService _emailNotificationService;

        public NewStudentUserCreatedIntegrationEventHandler(IStudentRepository studentRepository, IEmailNotificationService emailNotificationService)
        {
            _studentRepository = studentRepository;
            _emailNotificationService = emailNotificationService;
        }

        public async Task Handle(NewStudentUserCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            DomainException.ThrowIfNull(notification, DomainErrors.Student.NotFound);

            var student = new Domain.Entities.Student(
                notification.Id,
                notification.FirstName,
                notification.LastName,
                notification.CellPhone,
                notification.DateOfBirth,
                notification.Document);

            await _studentRepository.InsertAsync(student, cancellationToken);

            await _studentRepository.UnitOfWork.Commit(cancellationToken);

            var welcomeToFirstAccessEmail = new WelcomeToFirstAccessEmail(notification.Email!, notification.FirstName, notification.TemporaryPassword);

            await _emailNotificationService.SendWelcomeToFirstAccessEmail(welcomeToFirstAccessEmail);
        }
    }
}
