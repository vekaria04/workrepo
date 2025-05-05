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
    public class EntityConfiguration : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.ToTable("Entity");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Value).HasMaxLength(5000).IsRequired().IsUnicode(false);
            builder.Property(e => e.IsActive).HasColumnName("IsActive");
            builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}
