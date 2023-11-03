using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class Repo<Entity> : IRepository<Entity>
        where Entity : class
    {
        private readonly LibraryContext _dbContext;
        protected DbSet<Entity> EntrySet
        {
            get
            {
                return _dbContext.Set<Entity>();
            }
        }

        public Repo(LibraryContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public virtual async Task<IEnumerable<Entity>> GetAll()
        {
            return await EntrySet.AsNoTracking().ToListAsync();
        }
        public virtual async Task<Entity> Get(int id)
        {
            return await EntrySet.FindAsync(id);
        }
        public async Task<Entity> Create(Entity entity)
        {
            EntrySet.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task Update(Entity entity)
        {
            EntrySet.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var data = await EntrySet.FindAsync(id);
            EntrySet.Remove(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}
