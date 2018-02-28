using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobinhood.API.Csharp.Client.Configuration
{
    public static class NlogConfig
    {
        public static void Configure() {
            var config = new NLog.Config.LoggingConfiguration();

            var fileTarget = new NLog.Targets.FileTarget() { FileName = "${basedir}/log.txt", Name = "logfile", Layout = "${longdate} ${message} ${exception:format=tostring}" };
            config.LoggingRules.Add(new NLog.Config.LoggingRule("*", LogLevel.Trace, fileTarget));

            LogManager.Configuration = config;
        }
    }
}
