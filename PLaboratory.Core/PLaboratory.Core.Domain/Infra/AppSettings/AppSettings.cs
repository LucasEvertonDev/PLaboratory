﻿using Microsoft.Extensions.Configuration;

namespace PLaboratory.Core.Domain.Infra.AppSettings;

public class AppSettings
{
    public AppSettings()
    {
        MemoryCache = new MemoryCacheConfig(5, 10);
        Messages = new Messages();
        Log = new Log("Warning");
        SqlConnections = new SqlConnections("", "");
    }
    public AppSettings(IConfiguration config)
    {
        SqlConnections = new SqlConnections(config.GetConnectionString("SqlConnection"), config.GetConnectionString("SerilogSqlConnection") ?? config.GetConnectionString("SqlConnection"));

        MemoryCache = new MemoryCacheConfig(
            slidingExpirationInMinutes: int.Parse(config["MemoryCache:SlidingExpirationInMinutes"] ?? "1"),
            absoluteExpirationInMinutes: int.Parse(config["MemoryCache:SlidingExpirationInMinutes"] ?? "1")
        );

        Messages = new Messages();

        Log = new Log(config["Logging:LogLevel:Serilog"] ?? "Warning");
    }
    public SqlConnections SqlConnections { get; set; }

    public MemoryCacheConfig MemoryCache { get; set; }

    public Messages Messages { get; set; }

    public Log Log { get; set; }
}

public class SqlConnections
{
    public SqlConnections(string dbconnection, string serilogConection)
    {
        DbConnection = dbconnection;
        SerilogConnection = serilogConection;
    }

    public string DbConnection { get; set; }
    public string SerilogConnection { get; set; }
}

public class MemoryCacheConfig
{
    public MemoryCacheConfig(long slidingExpirationInMinutes, long absoluteExpirationInMinutes)
    {
        SlidingExpirationInMinutes = slidingExpirationInMinutes;
        AbsoluteExpirationInMinutes = absoluteExpirationInMinutes;
    }

    public long SlidingExpirationInMinutes { get; set; }

    public long AbsoluteExpirationInMinutes { get; set; }
}

public class Messages
{
    public string Forbidden { get; set; } = "Não autorizado. Credenciais fornecidas ausentes, inválidas ou expiradas";

    public string Unauthorized { get; set; } = "Acesso negado. Você não tem permissões suficientes para acessar esta API";
}


public class Log
{
    public Log(string logLevel)
    {
        LogLevel = logLevel;
    }

    public string LogLevel { get; set; }
}