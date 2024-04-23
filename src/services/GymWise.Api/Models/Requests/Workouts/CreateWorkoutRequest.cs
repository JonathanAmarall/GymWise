using GymWise.Workout.Application.Workouts.Commands.CreateWorkoutAndSetsCommand;
using GymWise.Workout.Domain.Entities;

namespace GymWise.Api.Models.Requests.Workouts
{
    public record CreateWorkoutRequest
    {
        public string Title { get; init; } = string.Empty;
        public WorkoutType? Type { get; init; }
        public string? Observations { get; init; }
        public Guid WorkoutRoutineId { get; init; }
        public IEnumerable<CreateSetsRequest> Sets { get; init; } = Enumerable.Empty<CreateSetsRequest>();

        public CreateWorkoutCommand CreateCommand()
        {
            var sets = Sets.Select(s => new CreateSetsCommand(s.Reps, s.Series, s.IntervalsInSeconds, s.Weight, s.AdvancedTechnique, s.ExerciseId));
            return new CreateWorkoutCommand(Title, Type, Observations, WorkoutRoutineId, sets);
        }
    }
}
