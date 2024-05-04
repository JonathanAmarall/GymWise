using GymWise.Api.Models;
using GymWise.Core.Contracts.Messaging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GymWise.Api.Data
{
    public class IdentityContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.ApplyConfigurationsFromAssembly(typeof(IdentityContext).Assembly);

            builder.Ignore<IDomainEvent>();

            base.OnModelCreating(builder);
        }
    }
}
