using GymWise.Api.Configuration;
using GymWise.Api.Data;
using GymWise.Api.Services;
using GymWise.Student.Application;
using GymWise.Student.Infra;
using GymWise.Workout.Application;
using GymWise.Workout.Infra;
using GymWise.Workout.Infra.Seeder;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddCorsConfiguration();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IdentityContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("IdentityConnection"));
});
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddIdentityConfiguration();
builder.Services.AddJwtConfiguration(configuration);

builder.Services
        .AddWorkoutApplication()
        .AddWorkoutInfrastructure(configuration)
        .AddStudentApplication()
        .AddStudentInfrastructure(configuration);

builder.Services.AddScoped<ITokenService, TokenJwtService>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

DataSeeder.ApplySeeders(app.Services).Wait();
RolesSeeder.Apply(app.Services).Wait();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();