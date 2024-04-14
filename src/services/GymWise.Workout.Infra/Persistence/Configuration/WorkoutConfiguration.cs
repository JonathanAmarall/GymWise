using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymWise.Workout.Infra.Persistence.Configuration
{
    internal sealed class WorkoutConfiguration : IEntityTypeConfiguration<Domain.Entities.Workout>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Workout> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Type);

            builder.Property(t => t.Observations);

            builder.Property(tr => tr.CreatedOnUtc).IsRequired();

            builder.Property(tr => tr.UpdatedOnUtc);

            builder.Property(tr => tr.IsDeleted).HasDefaultValue(false);

            builder.HasQueryFilter(tr => !tr.IsDeleted);

            builder.Property(tr => tr.DeletedOnUtc);
            builder.HasOne(t => t.TrainingRoutine)
                .WithMany()
                .HasForeignKey(t => t.TrainingRoutineId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.Sets)
                .WithOne();
        }
    }
}
