using GymWise.Api.Configuration;
using GymWise.Core.Contracts.Notifications;
using GymWise.Core.Services.Email;
using GymWise.Core.Services.Email.Settings;
using GymWise.Core.Services.Notifications;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace GymWise.BackgroundTasks
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBackgroundTasks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddIdentityContext(configuration);
            services.AddIdentityConfiguration();
            services.Configure<MailSettings>(configuration.GetSection(MailSettings.SettingsKey));
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IEmailNotificationService, EmailNotificationService>();

            return services;
        }
    }
}