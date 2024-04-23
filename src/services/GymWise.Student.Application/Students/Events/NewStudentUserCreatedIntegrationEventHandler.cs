using GymWise.Core.Contracts;
using GymWise.Core.Errors;
using GymWise.Core.Events.IntegrationEvents;
using GymWise.Core.Exceptions;
using GymWise.Student.Domain.Repositories;

namespace GymWise.Student.Application.Students.Events
{
    internal sealed class NewStudentUserCreatedIntegrationEventHandler : IIntegrationEventHandler<NewStudentUserCreatedIntegrationEvent>
    {
        private readonly IStudentRepository _studentRepository;

        public NewStudentUserCreatedIntegrationEventHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
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

            Console.WriteLine(
                $"Seja bem-vindo {student.FullName}!\n" +
                $"Sua senha temporária é: {notification.TemporaryPassword}.\n" +
                $"Por favor, altere no seu primeiro acesso.");
        }
    }
}
