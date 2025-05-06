using System;

namespace NIA.OnlineApp.Data.Entities
{
    // Represents an error log entry stored in the database
    public class ErrorLog
    {
        // Primary key of the error log entry
        public int Id { get; set; }

        // The error message (e.g., ex.Message)
        public string Message { get; set; } = string.Empty;

        // The stack trace of the exception (can be null)
        public string? StackTrace { get; set; }

        // The timestamp when the error was logged
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
