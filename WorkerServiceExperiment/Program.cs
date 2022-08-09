using WorkerServiceExperiment;
using Serilog;
using Coravel;

IHost host = Host.CreateDefaultBuilder(args)
    .UseSerilog()
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddScheduler();
        services.AddTransient<ProcessScheduler>();
    })
    .Build();

host.Services.UseScheduler(scheduler =>
{
    var jobSchedule = scheduler.Schedule<ProcessScheduler>();
    jobSchedule.EverySeconds(2).PreventOverlapping("ProcessWorkerExperiment");
});

var progData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();


await host.RunAsync();
