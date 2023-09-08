using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MS.Libs.Core.Domain.Infra.AppSettings;
using MS.Libs.Infra.IoC.Extensions;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using System.Collections.ObjectModel;
using System.Data;

namespace PLaboratory.Infra.IoC.Extensions;

public static class SerilogExtensions
{
    public static void RegisterSerilogMySql(this HostBuilderContext app, IConfigurationBuilder configurationBuilder)
    {
        IConfigurationRoot config = configurationBuilder.Build();
        AppSettings appSettings = new AppSettings(config);

        //Serilog.Log.Logger = (ILogger)new LoggerConfiguration().Enrich.FromLogContext().Enrich.With<UserEnricher>().WriteTo.MySQL(appSettings.SqlConnections.SerilogConnection, "AppLogs", (LogEventLevel)Enum.Parse(typeof(LogEventLevel), appSettings.Log.LogLevel), levelSwitch: new LoggingLevelSwitch
        //{
        //    MinimumLevel = (LogEventLevel)Enum.Parse(typeof(LogEventLevel), appSettings.Log.LogLevel)
        //});
    }
}
