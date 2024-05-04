using GymWise.Core.Contracts.Messaging;
using GymWise.Core.Models.Result;
using GymWise.Workout.Domain.Entities;
using GymWise.Workout.Domain.Repositories;
using GymWise.Workout.Domain.ValueObjetcts;

namespace GymWise.Workout.Application.WorkoutRotines.Commands.CreateWorkoutRotine
{
    internal sealed class CreateWorkoutRotineCommandHandler : ICommandHandler<CreateWorkoutRotineCommand, Result<WorkoutRoutine>>
    {
        private readonly IWorkoutRotineRepository _workoutRotineRepository;

        public CreateWorkoutRotineCommandHandler(IWorkoutRotineRepository workoutRotineRepository)
        {
            _workoutRotineRepository = workoutRotineRepository;
        }

        public async Task<Result<WorkoutRoutine>> Handle(CreateWorkoutRotineCommand request, CancellationToken cancellationToken)
        {
            Result<Title> titleResult = Title.Create(request.Title);
            if (titleResult.IsFailure)
            {
                return Result.Failure<WorkoutRoutine>(titleResult.Error);
            }

            WorkoutRoutine workoutRoutine = new(
                request.StudentId,
                titleResult.Value,
                request.Observations,
                request.InactiveOnExpiration,
                request.Active,
                request.ExpirationDate,
                request.StartDate);

            await _workoutRotineRepository.InsertAsync(workoutRoutine);

            await _workoutRotineRepository.UnitOfWork.Commit(cancellationToken);

            return Result.Success(workoutRoutine);
        }
    }
}
