using CentralLoggerSystem.Models;

namespace CentralLoggerSystem.Repositorys
{
    public interface ILoggerRepository
    {
        Task<int> AddLogsAsync(TextMessage message);
    }
}