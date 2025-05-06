using System;
using Microsoft.EntityFrameworkCore;
using NIA.OnlineApp.Data.Entities;
using NIA.OnlineApp.Data.Configurations;

namespace NIA.OnlineApp.Data
{
    // Represents the database context used by Entity Framework Core
    public class AppDbContext : DbContext
    {
        // Constructor that accepts DbContext options (e.g., connection string)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Represents the Entities table in the database
        public DbSet<Entity> Entities { get; set; }

        // Represents the ErrorLogs table in the database
        public DbSet<ErrorLog> ErrorLogs { get; set; }

        // Called when the model is being created; used to apply configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply configuration rules for the Entity table
            modelBuilder.ApplyConfiguration(new EntityConfiguration());

            // Apply configuration rules for the ErrorLog table
            modelBuilder.ApplyConfiguration(new ErrorLogConfiguration());
        }
    }
}
