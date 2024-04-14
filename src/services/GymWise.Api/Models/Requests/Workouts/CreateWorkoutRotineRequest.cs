using GymWise.Workout.Application.WorkoutRotines.Commands.CreateWorkoutRotine;

namespace GymWise.Api.Models.Requests.WorkoutRotine
{
    public record CreateWorkoutRotineRequest
    {
        public string Title { get; init; } = string.Empty;
        public string? Observations { get; init; }
        public bool Active { get; init; }
        public bool InactiveOnExpiration { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? ExpirationDate { get; init; }

        public CreateWorkoutRotineCommand CreateCommand()
        {
            return new CreateWorkoutRotineCommand(
                Title,
                Observations,
                Active,
                InactiveOnExpiration,
                StartDate,
                ExpirationDate);
        }
    }
}
