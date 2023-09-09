using PLaboratory.Infra.IoC.Extensions;
using PLaboratory.WebAPI.Infrastructure;
using Serilog;
using Serilog.Events;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration((hostingContext, config) =>
             {
                 hostingContext.RegisterSerilogMySql(config);
             })
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.UseIISIntegration();
            });
}