using Core.Utilities.Results;
using Entities.Concrete.Entity;

namespace Business.Abstract
{
    public interface IProductManager
    {
        IResult Add(Product product);
        IDataResult<List<Product>> GetAll();
    }
}
