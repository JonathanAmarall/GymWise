using GymWise.Core.Contracts.Messaging;
using GymWise.Core.Models.Maybe;

namespace GymWise.Workout.Application.Workouts.Queries.GetWorkoutByStudentId
{
    public sealed record GetWorkoutByStudentIdQuery(Guid StudentId) : IQuery<Maybe<Domain.Entities.Workout?>>;
}
