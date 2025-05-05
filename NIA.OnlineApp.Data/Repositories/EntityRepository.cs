using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NIA.OnlineApp.Data.Entities;

namespace NIA.OnlineApp.Data.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private readonly AppDbContext _context;

        public EntityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Entity> AddAsync(Entity entity)
        {
            entity.CreatedDate = DateTime.Now;
            _context.Entities.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await _context.Entities.ToListAsync();
        }

        public async Task<Entity?> GetByIdAsync(int id)
        {
            return await _context.Entities.FindAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Entities.FindAsync(id);
            if (entity == null) return false;

            _context.Entities.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Entity?> UpdateAsync(Entity entity)
        {
            var existing = await _context.Entities.FindAsync(entity.Id);
            if (existing == null) return null;

            existing.Value = entity.Value;
            existing.IsActive = entity.IsActive;

            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
