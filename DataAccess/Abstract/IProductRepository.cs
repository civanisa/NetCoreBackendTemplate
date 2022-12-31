using Core.DataAccess.EntityFramework;
using Entities.Concrete.Entity;

namespace DataAccess.Abstract
{
    public interface IProductRepository : IEntityRepositoryBase<Product>
    {
    }
}
