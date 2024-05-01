using GymWise.Api.Configuration;
using GymWise.Api.Configuration.HealthCheck;
using GymWise.Api.Data;
using GymWise.Api.Services;
using GymWise.Core.Configurations;
using GymWise.Student.Application;
using GymWise.Student.Infra;
using GymWise.Workout.Application;
using GymWise.Workout.Infra;
using GymWise.Workout.Infra.Seeder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

var configuration = builder.Configuration;
builder.Services.AddCorsConfiguration();
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    }).ConfigureInvalidStateApiBehavior();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IdentityContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("IdentityConnection"));
});
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddIdentityConfiguration();
builder.Services.AddJwtConfiguration(configuration);
builder.Services.AddHealthChecks(configuration);
builder.Services
        .AddWorkoutApplication()
        .AddWorkoutInfrastructure(configuration)
        .AddStudentApplication()
        .AddStudentInfrastructure(configuration);

builder.Services.AddScoped<ITokenService, TokenJwtService>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    DataSeeder.ApplySeeders(app.Services).Wait();
    RolesSeeder.Apply(app.Services).Wait();
    GymWise.Student.Infra.DependencyInjection.EnsureCreatedStudentDb(app.Services);
}
app.MapHealthChecks("/health", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = CustomUIResponseWriter.WriteHealthCheckResponse
});

app.UseCors(CorsPolicy.Name);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
