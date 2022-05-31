using System.Threading.Tasks;
using TodoAppNTier.DataAccess.Contexts;
using TodoAppNTier.DataAccess.Interfaces;
using TodoAppNTier.DataAccess.Repositories;
using TodoAppNTier.Entities.Concrete;

namespace TodoAppNTier.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly TodoContext _context;

        public Uow(TodoContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity, new()
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
