using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace GymWise.Api.Configuration.HealthCheck
{
    public static class CustomUIResponseWriter
    {
        public static Task WriteHealthCheckResponse(HttpContext httpContext, HealthReport result)
        {
            httpContext.Response.ContentType = "application/json";
            JObject jObject = BuildResponseObject(result);
            ReportCheckStatus(result.Status, jObject);
            return httpContext.Response.WriteAsync(jObject.ToString(Formatting.Indented));
        }

        private static JObject BuildResponseObject(HealthReport result)
        {
            Assembly? entryAssembly = Assembly.GetEntryAssembly();
            return new JObject(
                new JProperty("ApplicationName", entryAssembly?.GetName().Name),
                new JProperty("Version", entryAssembly!.GetName().Version!.ToString()),
                new JProperty("BuildDate", new FileInfo(entryAssembly.Location).CreationTime),
                new JProperty("MachineName", Environment.MachineName),
                new JProperty("Timestamp", DateTime.Now),
                new JProperty("status", result.Status.ToString()),
                new JProperty("components",
                    new JObject(result.Entries.Select((pair)
                         => new JProperty(pair.Key, new JObject(new JProperty("exception", pair.Value.Exception != null
                            ? pair.Value.Exception!.ToString() : ""),
                            new JProperty("status", pair.Value.Status.ToString()),
                            new JProperty("applicationName", pair.Value.Description),
                            new JProperty("data", new JObject(pair.Value.Data.Select((p) => new JProperty(p.Key, p.Value)))),
                            new JProperty("ElapsedTimeInSeconds", pair.Value.Duration.TotalSeconds)))))),
                            new JProperty("ElapsedTimeInSeconds", result.TotalDuration.TotalSeconds));
        }

        private static void ReportCheckStatus(HealthStatus status, JObject result)
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<HealthStatus>();
            logger.LogInformation("Status {status}\nResponse{result}", status, result);
        }
    }

}