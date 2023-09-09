using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog.Core;
using Serilog.Events;
using Serilog;
using PLaboratory.Core.Domain.Infra.AppSettings;

namespace PLaboratory.Infra.IoC.Extensions;

public static class SerilogExtensions
{
    public static void RegisterSerilogMySql(this HostBuilderContext app, IConfigurationBuilder configurationBuilder)
    {
        IConfigurationRoot config = configurationBuilder.Build();
        AppSettings appSettings = new AppSettings(config);
        // Para customizar colunas tem que ir lá no github e customizar mas o código é bastante bossal molezinha
        Serilog.Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.With<UserEnricher>()
            .WriteTo.MySQL(
                appSettings.SqlConnections.SerilogConnection,
                "AppLogs",
                (LogEventLevel)Enum.Parse(typeof(LogEventLevel), appSettings.Log.LogLevel),
                levelSwitch: new LoggingLevelSwitch
                {
                    MinimumLevel = (LogEventLevel)Enum.Parse(typeof(LogEventLevel), appSettings.Log.LogLevel)
                })
            .WriteTo.Console()
            .CreateLogger();
    }
}
