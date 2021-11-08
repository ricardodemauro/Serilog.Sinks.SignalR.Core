using Serilog.Sinks.SignalR.Core;
using Carter;
using Serilog;
using SerilogSignalR.Server.BackgroundServices;
using SerilogSignalR.Server.Hubs;
using Serilog.Sinks.SignalR.Core.Sinks.Data;
using Microsoft.AspNetCore.SignalR;
using Serilog.Sinks.SignalR.Core.Sinks.Interfaces;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

builder.Services.AddCarter();
builder.Services.AddSignalR();

builder.Services.AddHostedService<TimedHostedService>();

var app = builder.Build();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.SignalR<LoggingHub, ISerilogHub>(app.Services.GetRequiredService<IHubContext<LoggingHub, ISerilogHub>>()   )
    .CreateBootstrapLogger();

app.UseSerilogRequestLogging();

app.UseStaticFiles();

app.MapCarter();

app.MapHub<LoggingHub>("/loggingHub");

app.Run();
