using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TodoAppNTier.Entities.Concrete;

namespace TodoAppNTier.DataAccess.Interfaces
{
    public interface IRepository<T>
        where T : BaseEntity, new()
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        Task<T> Get(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        Task Create(T entity);
        void Update(T entity);
        void Remove(int id);
        IQueryable<T> GetQuery();
    }
}
