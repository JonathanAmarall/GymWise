using GymWise.BackgroundTasks;
using GymWise.Services.Notifications;
IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddBackgroundTasks(hostContext.Configuration);
    })
    .Build();

host.Run();
