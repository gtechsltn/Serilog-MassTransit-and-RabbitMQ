using CentralLoggerSystem.Data;
using CentralLoggerSystem.Models;
using System;
using Dapper;

namespace CentralLoggerSystem.Repositorys
{
    public class LoggerRepository : ILoggerRepository
    {
        private readonly DapperContext _context;

        public LoggerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> AddLogsAsync(TextMessage message)
        {
            const string sql = "INSERT INTO automappertest.loggers(Level, Message,dates) VALUES (@Level, @Message,@Timestamp) RETURNING Id"; // Adjust as needed

            try
            {
                using (var connection = _context.CreateConnection())
                {

                    return await connection.ExecuteAsync(sql, message);

                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


    }
}
