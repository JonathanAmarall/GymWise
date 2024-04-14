using GymWise.Workout.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymWise.Workout.Infra.Persistence.Configuration
{
    internal sealed class SetsConfiguration : IEntityTypeConfiguration<Sets>
    {
        public void Configure(EntityTypeBuilder<Sets> builder)
        {
            builder.ToTable("Sets");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Reps).IsRequired();

            builder.Property(s => s.Series).IsRequired();

            builder.Property(s => s.IntervalsInSeconds);

            builder.Property(s => s.Weight);

            builder.Property(s => s.AdvancedTechnique).HasMaxLength(150);

            builder.Property(tr => tr.CreatedOnUtc).IsRequired();

            builder.Property(tr => tr.UpdatedOnUtc);

            builder.Property(tr => tr.IsDeleted).HasDefaultValue(false);

            builder.HasQueryFilter(tr => !tr.IsDeleted);

            builder.Property(tr => tr.DeletedOnUtc);

            builder.HasOne(s => s.Exercise)
                .WithMany()
                .HasForeignKey(s => s.ExerciseId)
                .IsRequired();
        }
    }
}
