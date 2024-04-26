using GymWise.Core.Contracts;
using GymWise.Core.Models.ValueObjects;
using GymWise.Core.Primitives;
using GymWise.Student.Domain.ValueObjects;

namespace GymWise.Student.Domain.Entities
{
    public class Student : AggregateRoot, IAuditableEntity, ISoftDeletable
    {
        private Student() { }
        public Student(Guid id, string firstName, string lastName, string cellPhone, DateTime dateOfBirth, Document document) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            CellPhone = cellPhone;
            DateOfBirth = dateOfBirth;
            Document = document;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string CellPhone { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Document Document { get; private set; }

        public string FullName => $"{FirstName} {LastName}";
        public short? HeightInCentimeters { get; private set; }
        public short? WeightInKilograms { get; private set; }
        public Gender? Gender { get; private set; }
        public Address? Address { get; private set; }
        public string? TrainingGoals { get; private set; }
        public string? MedicalRestrictionsorInjuries { get; private set; }
        public string? TrainingExperienceLevel { get; private set; }
        public DateTime CreatedOnUtc { get; private set; }
        public DateTime? UpdatedOnUtc { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedOnUtc { get; private set; }

        public void AddAddress(Address address)
        {
            Address = address;
        }

        //Membership/Subscription Plan
        //Payment Status
        //Profile Picture
    }
}
