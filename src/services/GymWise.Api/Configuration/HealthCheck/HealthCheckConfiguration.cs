using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace GymWise.Api.Configuration.HealthCheck
{
    public static class HealthCheckConfiguration
    {
        const string ConnectionStringsSectionName = "ConnectionStrings";
        public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionsString = configuration?.GetRequiredSection(ConnectionStringsSectionName).AsEnumerable();

            var healthCheckBuilder = services
                .AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy());

            if (connectionsString != null)
            {
                foreach (var connection in connectionsString)
                {
                    if (connection.Value is null)
                    {
                        continue;
                    }

                    healthCheckBuilder.AddNpgSql(connection.Value, name: GetServiceName(connection));
                }
            }

            return services;
        }

        private static string GetServiceName(KeyValuePair<string, string?> connection)
            => connection.Key.Replace($"{ConnectionStringsSectionName}:", string.Empty);
    }
}
