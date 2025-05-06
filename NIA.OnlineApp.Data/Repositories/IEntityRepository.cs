using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NIA.OnlineApp.Data.Entities;

namespace NIA.OnlineApp.Data.Repositories
{
    // Defines a contract for performing CRUD operations on Entity objects
    public interface IEntityRepository
    {
        // Adds a new Entity to the database
        Task<Entity> AddAsync(Entity entity);

        // Retrieves all Entity records from the database
        Task<IEnumerable<Entity>> GetAllAsync();

        // Retrieves a specific Entity by its ID
        Task<Entity?> GetByIdAsync(int id);

        // Deletes an Entity by its ID
        Task<bool> DeleteAsync(int id);

        // Updates an existing Entity
        Task<Entity?> UpdateAsync(Entity entity);
    }
}
