using GymWise.Core.Contracts;
using GymWise.Core.Models.Maybe;
using GymWise.Workout.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GymWise.Workout.Application.Workouts.Queries.GetWorkoutByStudentId
{
    internal sealed class GetWorkoutByStudentIdQueryHandler : IQueryHandler<GetWorkoutByStudentIdQuery, Maybe<Domain.Entities.Workout?>>
    {
        private readonly WorkoutDbContext _context;

        public GetWorkoutByStudentIdQueryHandler(WorkoutDbContext context)
        {
            _context = context;
        }

        public async Task<Maybe<Domain.Entities.Workout?>> Handle(GetWorkoutByStudentIdQuery request, CancellationToken cancellationToken)
        {
            var workout = await _context.Set<Domain.Entities.Workout>()
                .Include(x => x.WorkoutRoutine)
                    .AsNoTracking()
                    .Where(x => x.WorkoutRoutine != null)
                .Include(x => x.Sets)
                    .ThenInclude(x => x.Exercise)
                    .AsNoTracking()
                .FirstOrDefaultAsync(x => x.WorkoutRoutine!.StudentId == request.StudentId, cancellationToken: cancellationToken);

            return Maybe<Domain.Entities.Workout?>.From(workout);
        }
    }
}
