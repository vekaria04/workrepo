using System;
using System.Threading.Tasks;
using NIA.OnlineApp.Data.Entities;

namespace NIA.OnlineApp.Data.Repositories
{
    // Defines a contract for logging exceptions to the database
    public interface IErrorLoggerRepository
    {
        // Logs the given exception asynchronously to the ErrorLogs table
        Task LogAsync(Exception ex);
    }
}
