
namespace CentralLoggerSystem.Services
{
    public interface ILoggerService
    {
        Task LogInfo(string message);

        Task LogError(string message);
    }
}