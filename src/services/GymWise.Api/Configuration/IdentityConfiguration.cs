using GymWise.Api.Data;
using GymWise.Api.Models;
using GymWise.Core.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GymWise.Api.Configuration
{
    public static class IdentityConfiguration
    {
        public static void AddIdentityConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
            .AddRoles<IdentityRole<Guid>>()
            .AddRoleManager<RoleManager<IdentityRole<Guid>>>()
            .AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultTokenProviders();
        }

        public static void AddIdentityContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("IdentityConnection"));
            });
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
    }

    public static class RolesSeeder
    {
        public static async Task Apply(IServiceProvider serviceProvider)
        {
            var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
            {
                using var scope = scopeFactory.CreateScope();

                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

                if (!await roleManager.RoleExistsAsync(Roles.Student))
                {
                    await roleManager.CreateAsync(new(Roles.Student));
                }

                if (!await roleManager.RoleExistsAsync(Roles.Host))
                {
                    await roleManager.CreateAsync(new(Roles.Host));
                }

                if (!await roleManager.RoleExistsAsync(Roles.PersonalTrainer))
                {
                    await roleManager.CreateAsync(new(Roles.PersonalTrainer));
                }
            }
        }
    }
}
