using GymWise.Api;
using GymWise.Api.Configuration;
using GymWise.Workout.Application;
using GymWise.Workout.Infra;
using GymWise.Workout.Infra.Seeder;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddCorsConfiguration();
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
        .AddApplication()
        .AddInfrastructure(configuration);

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

DataSeeder.ApplySeeders(app.Services).Wait();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();