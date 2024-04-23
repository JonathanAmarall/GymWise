using GymWise.Workout.Application.WorkoutRotines.Commands.CreateWorkoutRotine;
using System.ComponentModel.DataAnnotations;

namespace GymWise.Api.Models.Requests.WorkoutRotine
{
    public record CreateWorkoutRotineRequest
    {
        [Required]
        [MaxLength(Workout.Domain.ValueObjetcts.Title.MaxLength)]
        public string Title { get; init; } = string.Empty;
        public string? Observations { get; init; }
        public bool Active { get; init; }
        public bool InactiveOnExpiration { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? ExpirationDate { get; init; }
        public Guid? StudentId { get; init; }
        public CreateWorkoutRotineCommand CreateCommand()
        {
            return new CreateWorkoutRotineCommand(
                StudentId,
                Title,
                Observations,
                Active,
                InactiveOnExpiration,
                StartDate,
                ExpirationDate);
        }
    }
}
