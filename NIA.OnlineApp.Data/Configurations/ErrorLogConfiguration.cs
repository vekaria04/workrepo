using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NIA.OnlineApp.Data.Entities;

namespace NIA.OnlineApp.Data.Configurations
{
    public class ErrorLogConfiguration : IEntityTypeConfiguration<ErrorLog>
    {
        public void Configure(EntityTypeBuilder<ErrorLog> builder) 
        {
            builder.Property(e => e.Message).HasMaxLength(2000).IsRequired();
            builder.Property(e => e.StackTrace).HasMaxLength(4000);
        }
    }
}
