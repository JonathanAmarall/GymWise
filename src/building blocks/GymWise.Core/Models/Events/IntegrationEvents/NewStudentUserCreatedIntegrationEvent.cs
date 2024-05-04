using GymWise.Core.Contracts.Messaging;
using GymWise.Core.Models.ValueObjects;

namespace GymWise.Core.Models.Events.IntegrationEvents
{
    public class NewStudentUserCreatedIntegrationEvent : IIntegrationEvent
    {
        public NewStudentUserCreatedIntegrationEvent(Guid id, string firstName, string lastName, string cellPhone, DateTime dateOfBirth, Document document, string temporaryPassword, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CellPhone = cellPhone;
            DateOfBirth = dateOfBirth;
            Document = document;
            TemporaryPassword = temporaryPassword;
            Email = email;
        }

        public Guid Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string CellPhone { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Document Document { get; private set; }
        public string TemporaryPassword { get; private set; }
        public string Email { get; private set; }
    }
}
