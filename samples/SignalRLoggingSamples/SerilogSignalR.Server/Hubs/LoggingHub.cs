using Microsoft.AspNetCore.SignalR;
using Serilog.Sinks.SignalR.Core.Sinks.Data;
using Serilog.Sinks.SignalR.Core.Sinks.Interfaces;

namespace SerilogSignalR.Server.Hubs
{
    public class LoggingHub : Hub<ISerilogHub>, ISerilogHub
    {
        public Task PushEventLog(LogEvent message)
        {
            return Clients.All.PushEventLog(message);
        }
    }
}
