using GymWise.Workout.Domain.Entities;
using GymWise.Workout.Domain.ValueObjetcts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymWise.Workout.Infra.Persistence.Configuration
{
    internal sealed class WorkoutRotineConfiguration : IEntityTypeConfiguration<WorkoutRoutine>
    {
        public void Configure(EntityTypeBuilder<WorkoutRoutine> builder)
        {
            builder.HasKey(tr => tr.Id);

            builder.OwnsOne(tr => tr.Title, titleBuilder =>
            {
                titleBuilder.WithOwner();

                titleBuilder.Property(title => title.Value)
                .HasColumnName(nameof(WorkoutRoutine.Title))
                .HasMaxLength(Title.MaxLength)
                .IsRequired();
            });

            builder.Property(tr => tr.StudentId);

            builder.Property(tr => tr.Observations);

            builder.Property(tr => tr.Active);

            builder.Property(tr => tr.InactiveOnExpiration);

            builder.Property(tr => tr.StartDate);

            builder.Property(tr => tr.ExpirationDate);

            builder.Property(tr => tr.CreatedOnUtc).IsRequired();

            builder.Property(tr => tr.UpdatedOnUtc);

            builder.Property(tr => tr.IsDeleted).HasDefaultValue(false);

            builder.HasQueryFilter(tr => !tr.IsDeleted);

            builder.Property(tr => tr.DeletedOnUtc);

            builder.HasMany(tr => tr.Workouts)
                .WithOne(t => t.WorkoutRoutine)
                .HasForeignKey(tr => tr.WorkoutRoutineId)
                .IsRequired();
        }
    }
}
