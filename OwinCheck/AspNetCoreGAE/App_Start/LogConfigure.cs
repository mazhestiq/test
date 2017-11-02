using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace AspNetCoreGAE.App_Start
{
    public class LogConfigure
    {
        public static void CreateLogger(IConfigurationRoot config)
        {
#if DEBUG
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();
#else
            Log.Logger = new LoggerConfiguration()
                .WriteTo.GoogleCloudLogging(new GoogleCloudLoggingSinkOptions("GoogleProjectId"))
                .CreateLogger();
#endif
        }
    }
}
