using GymWise.Core.Contracts;
using GymWise.Core.Models.Maybe;
using GymWise.Workout.Domain.Entities;
using GymWise.Workout.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymWise.Workout.Infra.Persistence.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly WorkoutDbContext _context;

        public WorkoutRepository(WorkoutDbContext context)
            => _context = context;

        public IUnitOfWork UnitOfWork => _context;

        public async Task<bool> CheckExercisesExistsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
            => await _context.Set<Exercise>()
                .AnyAsync(workout => ids.Contains(workout.Id), cancellationToken);

        public async Task<Maybe<Domain.Entities.Workout?>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await _context.Set<Domain.Entities.Workout>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task InsertAsync(Domain.Entities.Workout workout, CancellationToken cancellationToken = default)
            => await _context.Set<Domain.Entities.Workout>().AddAsync(workout, cancellationToken);

        public void Remove(Guid id, CancellationToken cancellationToken = default)
        {
            var workout = _context.Set<Domain.Entities.Workout>().FirstOrDefault(x => x.Id == id);
            if (workout is null) { return; }
            _context.Set<Domain.Entities.Workout>().Remove(workout);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
        }
    }
}
