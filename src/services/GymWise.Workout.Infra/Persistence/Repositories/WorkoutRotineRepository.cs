using GymWise.Core.Contracts;
using GymWise.Core.Models.Maybe;
using GymWise.Workout.Domain.Entities;
using GymWise.Workout.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymWise.Workout.Infra.Persistence.Repositories
{
    internal class WorkoutRotineRepository : IWorkoutRotineRepository
    {
        private readonly WorkoutDbContext _context;

        public WorkoutRotineRepository(WorkoutDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Maybe<WorkoutRoutine?>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<WorkoutRoutine>().FirstOrDefaultAsync(wr => wr.Id == id, cancellationToken);
        }

        public async Task InsertAsync(WorkoutRoutine workoutRoutine, CancellationToken cancellationToken = default)
        {
            await _context.Set<WorkoutRoutine>().AddAsync(workoutRoutine, cancellationToken);
        }

        public void Remove(Guid id, CancellationToken cancellationToken = default)
        {
            var workoutRotine = _context.Set<WorkoutRoutine>().FirstOrDefault(wr => wr.Id == id);
            if (workoutRotine is null) { return; }
            _context.Set<WorkoutRoutine>().Remove(workoutRotine!);
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
