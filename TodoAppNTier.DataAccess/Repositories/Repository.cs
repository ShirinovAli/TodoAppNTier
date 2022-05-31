using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TodoAppNTier.DataAccess.Contexts;
using TodoAppNTier.DataAccess.Interfaces;
using TodoAppNTier.Entities.Concrete;

namespace TodoAppNTier.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly TodoContext _context;

        public Repository(TodoContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking ? await _context.Set<T>().SingleOrDefaultAsync(filter)
                                : await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter ==null ? await _context.Set<T>().ToListAsync()
                                 : await _context.Set<T>().Where(filter).ToListAsync();
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Remove(int id)
        {
            var deletedEntity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(deletedEntity);
        }

        public void Update(T entity)
        {
            var updatedEntity = _context.Set<T>().Find(entity.Id);
            _context.Entry(updatedEntity).CurrentValues.SetValues(entity);
        }
    }
}
