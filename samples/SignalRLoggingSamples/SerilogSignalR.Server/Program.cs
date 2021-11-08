using Carter;
using Serilog;
using SerilogSignalR.Server.BackgroundServices;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

builder.Services.AddCarter();
builder.Services.AddSignalR();

builder.Services.AddHostedService<TimedHostedService>();

var app = builder.Build();

app.UseSerilogRequestLogging();

app.UseStaticFiles();

app.MapCarter();

app.Run();
