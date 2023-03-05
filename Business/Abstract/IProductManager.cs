using Core.Utilities.Paging;
using Core.Utilities.Results;
using Entities.Concrete.Entity;

namespace Business.Abstract
{
    public interface IProductManager
    {
        IResult Add(Product product);
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> PaginateAllReturnList(Pageable pageable);
        IDataResult<IPaginate<Product>> PaginateAll(Pageable pageable);
    }
}
