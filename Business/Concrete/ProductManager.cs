using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.Entity;

namespace Business.Concrete
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(productRepository.GetAll(), Messages.ProductAdded);
        }
    }
}
