using GymWise.Core.Contracts;
using GymWise.Core.Models.Result;
using GymWise.Workout.Domain.Entities;

namespace GymWise.Workout.Application.Workouts.Commands.CreateWorkoutAndSetsCommand
{
    public record CreateWorkoutCommand : ICommand<Result<Domain.Entities.Workout>>
    {
        public CreateWorkoutCommand(string title, WorkoutType? type, string? observations, Guid workoutRoutineId, IEnumerable<CreateSetsCommand> sets)
        {
            Title = title;
            Type = type;
            Observations = observations;
            WorkoutRoutineId = workoutRoutineId;
            Sets = sets;
        }

        public string Title { get; init; } = string.Empty;
        public WorkoutType? Type { get; init; }
        public string? Observations { get; init; }
        public Guid WorkoutRoutineId { get; init; }
        public IEnumerable<CreateSetsCommand> Sets { get; init; } = Enumerable.Empty<CreateSetsCommand>();
    }
}
