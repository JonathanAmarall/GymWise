using GymWise.Core.Models.ValueObjects;
using GymWise.Student.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymWise.Student.Infra.Persistence.Configuration
{
    internal sealed class StudentConfiguration : IEntityTypeConfiguration<Domain.Entities.Student>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Student> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(s => s.FirstName).IsRequired();

            builder.Property(tr => tr.LastName).IsRequired();

            builder.Property(tr => tr.CellPhone).IsRequired();

            builder.Property(tr => tr.DateOfBirth).IsRequired();

            builder.Property(tr => tr.CellPhone);

            builder.OwnsOne(tr => tr.Document, docBuilder =>
            {
                docBuilder.WithOwner();
                docBuilder.Property(doc => doc.Value)
                .HasColumnName(nameof(Domain.Entities.Student.Document))
                .HasMaxLength(Document.MaxLength)
                .IsRequired();
            });

            builder.Ignore(tr => tr.FullName);

            builder.Property(tr => tr.HeightInCentimeters);

            builder.Property(tr => tr.WeightInKilograms);

            builder.Property(tr => tr.Gender);

            builder.OwnsOne(tr => tr.Address, addressBuilder =>
            {
                addressBuilder.WithOwner();

                addressBuilder.Property(address => address.Number)
                      .HasColumnName(nameof(Address.Number))
                      .HasMaxLength(Address.MaxNumberLength);

                addressBuilder.Property(address => address.City)
                      .HasColumnName(nameof(Address.City))
                      .HasMaxLength(Address.MaxCityLength);

                addressBuilder.Property(address => address.State)
                      .HasColumnName(nameof(Address.State))
                      .HasMaxLength(Address.MaxStateLength);

                addressBuilder.Property(address => address.Neighborhood)
                     .HasColumnName(nameof(Address.Neighborhood))
                     .HasMaxLength(Address.MaxNeighborhoodLength);

                addressBuilder.Property(address => address.ZipCode)
                    .HasColumnName(nameof(Address.ZipCode))
                    .HasMaxLength(Address.MaxZipCodeLength);
            });

            builder.Property(tr => tr.TrainingGoals);

            builder.Property(tr => tr.MedicalRestrictionsorInjuries);

            builder.Property(tr => tr.TrainingExperienceLevel);

            builder.Property(tr => tr.CreatedOnUtc).IsRequired();

            builder.Property(tr => tr.UpdatedOnUtc);

            builder.Property(tr => tr.IsDeleted).HasDefaultValue(false);

            builder.HasQueryFilter(tr => !tr.IsDeleted);

            builder.Property(tr => tr.DeletedOnUtc);

        }
    }
}
