using GymWise.Core.Contracts;
using GymWise.Core.Primitives;

namespace GymWise.Workout.Domain.Entities
{
    public sealed class Sets : EntityBase, IAuditableEntity, ISoftDeletable
    {
        public Sets(short reps, short series, short? intervalsInSeconds, short? weight, string? advancedTechnique, Guid exerciseId)
        {
            Reps = reps;
            Series = series;
            IntervalsInSeconds = intervalsInSeconds;
            Weight = weight;
            AdvancedTechnique = advancedTechnique;
            ExerciseId = exerciseId;
        }

        public short Reps { get; private set; }
        public short Series { get; private set; }
        public short? IntervalsInSeconds { get; private set; }
        public short? Weight { get; private set; }
        public string? AdvancedTechnique { get; private set; }
        public DateTime CreatedOnUtc { get; private set; }
        public DateTime? UpdatedOnUtc { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedOnUtc { get; private set; }

        public Guid ExerciseId { get; private set; }
        public Exercise? Exercise { get; private set; }
    }
}
