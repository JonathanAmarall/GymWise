using GymWise.Workout.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymWise.Workout.Infra.Persistence.Configuration
{
    internal sealed class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.Property(s => s.Name).IsRequired();

            builder.Property(tr => tr.CreatedOnUtc).IsRequired();

            builder.Property(tr => tr.UpdatedOnUtc);

            builder.Property(tr => tr.IsDeleted).HasDefaultValue(false);

            builder.HasQueryFilter(tr => !tr.IsDeleted);

            builder.Property(tr => tr.DeletedOnUtc);
        }
    }
}
