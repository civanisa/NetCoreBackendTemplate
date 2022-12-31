using Core.Utilities.Results;
using Entities.Concrete.Entity;

namespace Business.Abstract
{
    public interface IProductManager
    {
        IDataResult<List<Product>> GetAll();
    }
}
