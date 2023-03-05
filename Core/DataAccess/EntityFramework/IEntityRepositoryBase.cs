using Core.Entities;
using Core.Utilities.Paging;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public interface IEntityRepositoryBase<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        List<T> PaginateAllReturnList(Pageable pageable, Expression<Func<T, bool>> filter = null);
        IPaginate<T> PaginateAll(Pageable pageable, Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
