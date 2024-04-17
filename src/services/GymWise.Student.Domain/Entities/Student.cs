using GymWise.Core.Primitives;
using GymWise.Student.Domain.ValueObjects;

namespace GymWise.Student.Domain.Entities
{
    public class Student : AggregateRoot
    {
        public Student(string firstName, string lastName, string cellPhone, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            CellPhone = cellPhone;
            DateOfBirth = dateOfBirth;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string CellPhone { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        //public Document Document { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public short? HeightInCentimeters { get; private set; }
        public short? WeightInKilograms { get; private set; }
        public Gender? Gender { get; private set; }
        public Address? Address { get; private set; }
        public string? TrainingGoals { get; private set; }
        public string? MedicalRestrictionsorInjuries { get; private set; }
        public string? TrainingExperienceLevel { get; private set; }

        //Membership/Subscription Plan
        //Payment Status
        //Profile Picture
    }
}
