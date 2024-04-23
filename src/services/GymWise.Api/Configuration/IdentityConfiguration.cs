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
}
