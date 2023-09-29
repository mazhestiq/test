using Serilog;
using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace Cinema.WebApi.Host
{
    public static class LogConfigure
    {
        public static ILogger CreateLogger()
        {
            var config = AppConfiguration.Configure();

            Log.Logger = new LoggerConfiguration()
                #if DEBUG
                .WriteTo.Console()
                #endif
                .WriteTo.File(config["LogPath"], rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Information)
                .CreateLogger();

            return Log.Logger;
        }
    }
}
