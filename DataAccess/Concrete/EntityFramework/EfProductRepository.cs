using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete.Entity;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductRepository : EfEntityRepositoryBase<Product,BaseContext>, IProductRepository
    {

    }
}
