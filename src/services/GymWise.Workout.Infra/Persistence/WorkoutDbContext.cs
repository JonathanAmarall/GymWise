﻿using GymWise.Core.Contracts.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace GymWise.Workout.Infra.Persistence
{
    public class WorkoutDbContext : DbContext, IUnitOfWork
    {
        public WorkoutDbContext(DbContextOptions<WorkoutDbContext> options) :
         base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkoutDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public void UpdateAuditableEntities(DateTime utcNow)
        {
            foreach (EntityEntry<IAuditableEntity> entityEntry in ChangeTracker.Entries<IAuditableEntity>())
            {
                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property(nameof(IAuditableEntity.CreatedOnUtc)).CurrentValue = utcNow;
                }

                if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Property(nameof(IAuditableEntity.UpdatedOnUtc)).CurrentValue = utcNow;
                }
            }
        }

        public async Task<bool> Commit(CancellationToken cancellationToken = default)
        {
            DateTime utcNow = DateTime.UtcNow;

            UpdateAuditableEntities(utcNow);
            return await SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
