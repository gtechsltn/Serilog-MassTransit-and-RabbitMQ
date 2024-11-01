using MassTransit.Logging;
using MassTransit;
using CentralLoggerSystem.Models;
using CentralLoggerSystem.Repositorys;

namespace CentralLoggerSystem.Consumers
{
    public class LogConsumer : IConsumer<TextMessage>
    {
        private readonly ILogger<LogConsumer> _logger;
        private readonly ILoggerRepository _loggerRepository;
        
        public LogConsumer(ILogger<LogConsumer> logger, ILoggerRepository loggerRepository)
        {
            _logger = logger;
            _loggerRepository = loggerRepository;
        }

        public async  Task Consume(ConsumeContext<TextMessage> context)
        {
            var logMessage = context.Message;
            //Console.WriteLine($"Received message: {context.Message.Message}");
            await _loggerRepository.AddLogsAsync(logMessage);

            _logger.LogInformation("Received message: {MessageId}", context.MessageId);
            // Process the message
            await Task.CompletedTask;
            _logger.LogInformation("Processed message: {MessageId}", context.MessageId);

        }
    }
}
