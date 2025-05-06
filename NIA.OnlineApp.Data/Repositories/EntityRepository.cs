using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NIA.OnlineApp.Data.Entities;

namespace NIA.OnlineApp.Data.Repositories
{
    // Implements the IEntityRepository interface to handle CRUD operations for Entity objects
    public class EntityRepository : IEntityRepository
    {
        // The database context used to interact with the Entity table
        private readonly AppDbContext _context;

        // Constructor that injects the AppDbContext
        public EntityRepository(AppDbContext context)
        {
            _context = context;
        }

        // Adds a new Entity to the database
        public async Task<Entity> AddAsync(Entity entity)
        {
            // Set the creation date to the current time
            entity.CreatedDate = DateTime.Now;

            // Add the entity and save changes
            _context.Entities.Add(entity);
            await _context.SaveChangesAsync();

            // Return the newly added entity
            return entity;
        }

        // Retrieves all Entity records from the database
        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await _context.Entities.ToListAsync();
        }

        // Retrieves a specific Entity by its ID
        public async Task<Entity?> GetByIdAsync(int id)
        {
            return await _context.Entities.FindAsync(id);
        }

        // Deletes an Entity by its ID
        public async Task<bool> DeleteAsync(int id)
        {
            // Find the entity to delete
            var entity = await _context.Entities.FindAsync(id);

            // Return false if not found
            if (entity == null) return false;

            // Remove the entity and save changes
            _context.Entities.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        // Updates an existing Entity with new values
        public async Task<Entity?> UpdateAsync(Entity entity)
        {
            // Find the existing entity by ID
            var existing = await _context.Entities.FindAsync(entity.Id);

            // Return null if not found
            if (existing == null) return null;

            // Update the fields
            existing.Value = entity.Value;
            existing.IsActive = entity.IsActive;

            // Save the changes
            await _context.SaveChangesAsync();

            return existing;
        }
    }
}
