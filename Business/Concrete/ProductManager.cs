using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.Entity;

namespace Business.Concrete
{
    public class ProductManager : IProductManager
    {
        #region Ctor
        private readonly IProductRepository productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        #endregion

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            productRepository.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        } 
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(productRepository.GetAll(), Messages.ProductAdded);
        }
    }
}
