using System;
using System.Threading.Tasks;
using NIA.OnlineApp.Data.Entities;

namespace NIA.OnlineApp.Data.Repositories
{
    // Provides an implementation of IErrorLoggerRepository for logging exceptions to the database
    public class ErrorLoggerRepository : IErrorLoggerRepository
    {
        // The database context used to access the ErrorLogs table
        private readonly AppDbContext _context;

        // Constructor that injects the AppDbContext
        public ErrorLoggerRepository(AppDbContext context)
        {
            _context = context;
        }

        // Logs the exception details to the ErrorLogs table
        public async Task LogAsync(Exception ex)
        {
            // Create a new ErrorLog record using the exception details
            var log = new ErrorLog
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace
            };

            // Add the log to the context and save it to the database
            _context.ErrorLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
