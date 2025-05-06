using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NIA.OnlineApp.Data.Entities;

namespace NIA.OnlineApp.Data.Configurations
{
    // Configures the schema details for the ErrorLog entity
    public class ErrorLogConfiguration : IEntityTypeConfiguration<ErrorLog>
    {
        // This method configures properties for the ErrorLog table
        public void Configure(EntityTypeBuilder<ErrorLog> builder)
        {
            // Set the maximum length of the Message column to 2000 and make it required (NOT NULL)
            builder.Property(e => e.Message).HasMaxLength(2000).IsRequired();

            // Set the maximum length of the StackTrace column to 4000 (nullable by default)
            builder.Property(e => e.StackTrace).HasMaxLength(4000);
        }
    }
}
