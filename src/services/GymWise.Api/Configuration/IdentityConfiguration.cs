using GymWise.Api.Data;
using GymWise.Api.Models;
using Microsoft.AspNetCore.Identity;

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

                if (!await roleManager.RoleExistsAsync(Core.Auth.Roles.PersonalTrainer))
                {
                    await roleManager.CreateAsync(new(Core.Auth.Roles.PersonalTrainer));
                }
            }
        }
    }
}
