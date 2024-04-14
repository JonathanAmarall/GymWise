using GymWise.Core.Contracts;
using GymWise.Core.Primitives;
using GymWise.Workout.Domain.ValueObjetcts;

namespace GymWise.Workout.Domain.Entities
{
    public sealed class WorkoutRoutine : AggregateRoot, IAuditableEntity, ISoftDeletable
    {
        protected WorkoutRoutine() { }
        public WorkoutRoutine(Title title, string? observations, bool inactiveOnExpiration, bool active, DateTime? expirationDate, DateTime? startDate)
        {
            Title = title;
            Observations = observations;
            InactiveOnExpiration = inactiveOnExpiration;
            ExpirationDate = expirationDate;
            StartDate = startDate;
            Active = active;
        }

        public Title Title { get; private set; }
        public string? Observations { get; private set; }
        public bool Active { get; private set; }
        public bool InactiveOnExpiration { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? ExpirationDate { get; private set; }
        public DateTime CreatedOnUtc { get; private set; }
        public DateTime? UpdatedOnUtc { get; private set; }
        public ICollection<Workout> Workouts { get; private set; } = Enumerable.Empty<Workout>().ToList();
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedOnUtc { get; private set; }

        public void AddWorkout(Workout workout)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(workout));
            Workouts.Add(workout);
        }
    }
}
