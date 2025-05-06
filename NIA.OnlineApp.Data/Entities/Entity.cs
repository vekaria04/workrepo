using System;

namespace NIA.OnlineApp.Data.Entities
{
    // Represents a generic entity record in the system
    public class Entity
    {
        // Primary key of the entity
        public int Id { get; set; }

        // The main string value (up to 5000 characters in the database)
        public string Value { get; set; } = string.Empty;

        // Indicates whether the entity is active or not
        public bool IsActive { get; set; }

        // The date and time when the entity was created
        public DateTime CreatedDate { get; set; }
    }
}
