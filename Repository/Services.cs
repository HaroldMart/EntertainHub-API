using Data;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Services<T> : IEntertainment<T>
        where T : class
    {
        private readonly LibraryContext _dbContext;
        private DbSet<T> EntrySet {
            get
            {
                return _dbContext.Set<T>();
            }}

        public Services(LibraryContext dbcontext) { 
            _dbContext = dbcontext;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await EntrySet.ToListAsync();
        }
        public async Task<T> Get(int id)
        {
            var data = await EntrySet.FindAsync(id);
            return data; 
        }
        public async Task<T> Create(T entity)
        {
            EntrySet.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task Update(T entity)
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
