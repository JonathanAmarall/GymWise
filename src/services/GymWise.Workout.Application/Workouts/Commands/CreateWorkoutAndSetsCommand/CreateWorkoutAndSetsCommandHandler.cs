using GymWise.Core.Contracts;
using GymWise.Core.Models.Result;
using GymWise.Core.Primitives;
using GymWise.Workout.Domain.Entities;
using GymWise.Workout.Domain.Repositories;

namespace GymWise.Workout.Application.Workouts.Commands.CreateWorkoutAndSetsCommand
{
    internal sealed class CreateWorkoutAndSetsCommandHandler : ICommandHandler<CreateWorkoutCommand, Result<Domain.Entities.Workout>>
    {
        private readonly IWorkoutRepository _workoutRepository;

        public CreateWorkoutAndSetsCommandHandler(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public async Task<Result<Domain.Entities.Workout>> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
        {
            if (!await CheckExercisesExists(request, cancellationToken))
            {
                return Result.Failure<Domain.Entities.Workout>(new Error("Workout.Exercise.NotFound", "Exercise not found."));
            }

            var workout = new Domain.Entities.Workout(request.Title, request.TrainingRoutineId, request.Observations);

            foreach (var sets in request.Sets)
            {
                var newSets = new Sets(
                    sets.Reps,
                    sets.Series,
                    sets.IntervalsInSeconds,
                    sets.Weight,
                    sets.AdvancedTechnique,
                    sets.ExerciseId);

                workout.AddSets(newSets);
            }

            await _workoutRepository.InsertAsync(workout, cancellationToken);

            await _workoutRepository.UnitOfWork.Commit(cancellationToken);

            return Result.Success(workout);
        }

        private async Task<bool> CheckExercisesExists(CreateWorkoutCommand request, CancellationToken cancellationToken)
            => await _workoutRepository.CheckExercisesExistsAsync(request.Sets.Select(sets => sets.ExerciseId), cancellationToken);
    }
}
