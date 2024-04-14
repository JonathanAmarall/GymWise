using GymWise.Core.Contracts;
using GymWise.Core.Models.Maybe;

namespace GymWise.Workout.Domain.Repositories
{
    public interface IWorkoutRepository : IRepository<Entities.Workout>
    {
        Task<bool> CheckExercisesExistsAsync(IEnumerable<Guid> enumerable, CancellationToken cancellationToken = default);

        Task<Maybe<Entities.Workout?>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task InsertAsync(Entities.Workout workout, CancellationToken cancellationToken = default);

        void Remove(Guid id, CancellationToken cancellationToken = default);
    }
}
