using GymWise.Api.Models;
using GymWise.Core.Contracts;
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

        public static class RolesSeeder
        {
            public static async Task Apply(IServiceProvider serviceProvider)
            {
                var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
                {
                    using var scope = scopeFactory.CreateScope();

                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

                    if (!await roleManager.RoleExistsAsync(Core.Auth.Roles.Student))
                    {
                        await roleManager.CreateAsync(new(Core.Auth.Roles.Student));

                    }

                    if (!await roleManager.RoleExistsAsync(Core.Auth.Roles.Host))
                    {
                        await roleManager.CreateAsync(new(Core.Auth.Roles.Host));
                    }
                }
            }
        }
    }
}
