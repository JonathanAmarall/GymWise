using GymWise.Student.Domain.Repositories;
using GymWise.Student.Infra.Persistence;
using GymWise.Student.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymWise.Student.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddStudentInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StudentDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("StudentConnection"));
            });

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddScoped<IStudentRepository, StudentRepository>();

            return services;
        }

        public static void EnsureCreatedStudentDb(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            using (var context = scope.ServiceProvider.GetService<StudentDbContext>())
                context!.Database.Migrate();

            Console.WriteLine("=================StudentDb created==================");
        }
    }
}