using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NIA.OnlineApp.Data
{
    // This class provides a way to create the AppDbContext at design time (e.g., for EF Core tools)
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        // This method is called by EF Core tools like 'dotnet ef' to create the DbContext
        public AppDbContext CreateDbContext(string[] args)
        {
            // Create a new DbContextOptionsBuilder for AppDbContext
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Configure the builder to use SQL Server with the connection string
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=NIA_DB;Trusted_Connection=True;Encrypt=False;");

            // Return a new AppDbContext instance using the configured options
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
