using GymWise.Core.Contracts.Messaging;
using GymWise.Core.Errors;
using GymWise.Core.Models.Result;
using GymWise.Workout.Domain.Entities;
using GymWise.Workout.Domain.Repositories;

namespace GymWise.Workout.Application.Workouts.Commands.CreateWorkoutAndSetsCommand
{
    internal sealed class CreateWorkoutAndSetsCommandHandler : ICommandHandler<CreateWorkoutCommand, Result<Domain.Entities.Workout>>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IWorkoutRotineRepository _routineRepository;

        public CreateWorkoutAndSetsCommandHandler(IWorkoutRepository workoutRepository, IWorkoutRotineRepository routineRepository)
        {
            _workoutRepository = workoutRepository;
            _routineRepository = routineRepository;
        }

        public async Task<Result<Domain.Entities.Workout>> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
        {
            if (!await CheckExercisesExists(request, cancellationToken))
            {
                return Result.Failure<Domain.Entities.Workout>(DomainErrors.Workout.NotFound);
            }

            if (!await _routineRepository.CheckExistsAsync(id: request.WorkoutRoutineId, cancellationToken))
            {
                return Result.Failure<Domain.Entities.Workout>(DomainErrors.WorkoutRotine.NotFound);
            }

            var workout = new Domain.Entities.Workout(request.Title, request.WorkoutRoutineId, request.Observations);

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
