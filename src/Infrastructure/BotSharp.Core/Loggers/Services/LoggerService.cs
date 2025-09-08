namespace BotSharp.Core.Loggers.Services;

public partial class LoggerService : ILoggerService
{
    private readonly IServiceProvider _services;
    private readonly ILogger<LoggerService> _logger;

    public LoggerService(
        IServiceProvider services,
        ILogger<LoggerService> logger)
    {
        _services = services;
        _logger = logger;
    }
}
