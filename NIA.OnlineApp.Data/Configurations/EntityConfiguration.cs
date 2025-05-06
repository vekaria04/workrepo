using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NIA.OnlineApp.Data.Entities;

namespace NIA.OnlineApp.Data.Configurations
{
    // Configures the schema details for the Entity table
    public class EntityConfiguration : IEntityTypeConfiguration<Entity>
    {
        // This method is used to configure the Entity properties and mappings
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            // Map this entity to the "Entity" table
            builder.ToTable("Entity");

            // Specify that the Id property is the primary key
            builder.HasKey(e => e.Id);

            // Configure the Value column: max 5000 characters, required, non-Unicode (varchar instead of nvarchar)
            builder.Property(e => e.Value)
                   .HasMaxLength(5000)
                   .IsRequired()
                   .IsUnicode(false);

            // Map the IsActive property to the "IsActive" column
            builder.Property(e => e.IsActive)
                   .HasColumnName("IsActive");

            // Map the CreatedDate property to the "CreatedDate" column
            builder.Property(e => e.CreatedDate)
                   .HasColumnName("CreatedDate");
        }
    }
}

