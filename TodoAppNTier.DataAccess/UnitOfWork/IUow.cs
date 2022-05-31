using System.Threading.Tasks;
using TodoAppNTier.DataAccess.Interfaces;
using TodoAppNTier.Entities.Concrete;

namespace TodoAppNTier.DataAccess.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity, new();
        Task SaveChanges();
    }
}
