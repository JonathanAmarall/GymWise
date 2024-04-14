using GymWise.Workout.Domain.Repositories;
using GymWise.Workout.Infra.Persistence;
using GymWise.Workout.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymWise.Workout.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WorkoutDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("WorkoutConnection"));
            });

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services
                .AddScoped<IWorkoutRotineRepository, WorkoutRotineRepository>()
                .AddScoped<IWorkoutRepository, WorkoutRepository>();

            return services;
        }
    }
}
