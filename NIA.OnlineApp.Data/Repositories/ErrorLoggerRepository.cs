using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NIA.OnlineApp.Data.Entities;

namespace NIA.OnlineApp.Data.Repositories
{
    public class ErrorLoggerRepository : IErrorLoggerRepository
    {
        private readonly AppDbContext _context;

        public ErrorLoggerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task LogAsync(Exception ex)
        {
            var log = new ErrorLog
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace
            };

            _context.ErrorLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
