using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProductManager
    {
        List<Product> GetAll();
    }
}
