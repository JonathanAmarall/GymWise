using GymWise.Core.Contracts;
using GymWise.Core.Primitives;

namespace GymWise.Workout.Domain.Entities
{
    public sealed class Workout : AggregateRoot, IAuditableEntity, ISoftDeletable
    {
        public Workout(string title, Guid trainingRoutineId, string? observations)
        {
            Title = title;
            TrainingRoutineId = trainingRoutineId;
            Observations = observations;
        }

        public string Title { get; private set; } = string.Empty;
        public WorkoutType? Type { get; private set; }
        public string? Observations { get; private set; }
        public DateTime CreatedOnUtc { get; private set; }
        public DateTime? UpdatedOnUtc { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedOnUtc { get; private set; }

        public Guid TrainingRoutineId { get; private set; }
        public WorkoutRoutine? TrainingRoutine { get; private set; }
        public ICollection<Sets> Sets { get; private set; } = Enumerable.Empty<Sets>().ToList();

        public void AddSets(Sets sets)
        {
            Sets.Add(sets);
        }
    }
}
