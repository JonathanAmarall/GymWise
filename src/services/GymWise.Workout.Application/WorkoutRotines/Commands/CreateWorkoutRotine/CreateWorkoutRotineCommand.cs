using GymWise.Core.Contracts.Messaging;
using GymWise.Core.Models.Result;
using GymWise.Workout.Domain.Entities;

namespace GymWise.Workout.Application.WorkoutRotines.Commands.CreateWorkoutRotine
{
    public record CreateWorkoutRotineCommand : ICommand<Result<WorkoutRoutine>>
    {
        public CreateWorkoutRotineCommand(Guid? studentId, string title, string? observations, bool active, bool inactiveOnExpiration, DateTime? startDate, DateTime? expirationDate)
        {
            StudentId = studentId;
            Title = title;
            Observations = observations;
            Active = active;
            InactiveOnExpiration = inactiveOnExpiration;
            StartDate = startDate;
            ExpirationDate = expirationDate;
        }

        public string Title { get; init; } = string.Empty;
        public string? Observations { get; init; }
        public bool Active { get; init; }
        public bool InactiveOnExpiration { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? ExpirationDate { get; init; }
        public Guid? StudentId { get; init; }
    }
}
