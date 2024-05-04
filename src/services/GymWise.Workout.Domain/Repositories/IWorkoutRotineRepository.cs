using GymWise.Core.Contracts.Domain;
using GymWise.Core.Models.Maybe;
using GymWise.Workout.Domain.Entities;

namespace GymWise.Workout.Domain.Repositories
{
    public interface IWorkoutRotineRepository : IRepository<WorkoutRoutine>
    {
        Task<bool> CheckExistsAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Maybe<WorkoutRoutine?>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task InsertAsync(WorkoutRoutine workoutRoutine, CancellationToken cancellationToken = default);

        void Remove(Guid id, CancellationToken cancellationToken = default);
    }
}
