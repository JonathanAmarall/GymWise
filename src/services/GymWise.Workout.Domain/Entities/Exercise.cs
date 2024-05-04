using GymWise.Core.Contracts.Domain;
using GymWise.Core.Models.Primitives;

namespace GymWise.Workout.Domain.Entities
{
    public sealed class Exercise : EntityBase, IAuditableEntity, ISoftDeletable
    {
        public Exercise(string name, string urlVideo)
        {
            Name = name;
            UrlVideo = urlVideo;
            IsDeleted = false;
        }

        public string Name { get; private set; } = string.Empty;
        public string? UrlVideo { get; private set; }

        public DateTime CreatedOnUtc { get; private set; }
        public DateTime? UpdatedOnUtc { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedOnUtc { get; private set; }
    }
}
