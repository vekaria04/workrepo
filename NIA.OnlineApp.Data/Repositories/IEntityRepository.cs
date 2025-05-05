using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NIA.OnlineApp.Data.Entities;

namespace NIA.OnlineApp.Data.Repositories
{
    public interface IEntityRepository
    {
        Task<Entity> AddAsync(Entity entity);
        Task<IEnumerable<Entity>> GetAllAsync();
        Task<Entity?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<Entity?> UpdateAsync(Entity entity);
    }
}

