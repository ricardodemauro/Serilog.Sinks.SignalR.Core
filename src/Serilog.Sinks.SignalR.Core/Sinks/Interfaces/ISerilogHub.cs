using Serilog.Sinks.SignalR.Core.Sinks.Data;
using System.Threading.Tasks;

namespace Serilog.Sinks.SignalR.Core.Sinks.Interfaces
{
    public interface ISerilogHub
    {
        Task PushEventLog(LogEvent message);
    }
}
