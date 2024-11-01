using MassTransit.Logging;
using MassTransit;
using CentralLoggerSystem.Models;
using System;
using System.Text.Json;

namespace CentralLoggerSystem.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly IBus _bus;
        private readonly ILogger<LoggerService> _logger;
        public LoggerService(IBus bus, ILogger<LoggerService> logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public async Task LogInfo(string message)
        {
            var logMessage = new TextMessage { Level = "Information", Message = message, Timestamp = DateTime.UtcNow };
            _logger.LogInformation("Publishing message: {MessageText}", JsonSerializer.Serialize(logMessage));

            await _bus.Publish(logMessage);
        }

        public async Task LogError(string message)
        {
            var logMessage = new TextMessage {Level="Error", Message = message, Timestamp = DateTime.UtcNow };
            _logger.LogError("Publishing message: {MessageText}", JsonSerializer.Serialize(logMessage));

            await _bus.Publish(logMessage);
        }

    }
}
