using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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

        [SecuredOperation("product.add,admin")]
        [Validation(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName),
                CheckIfProductCountCategoryCorrent(product.CategoryId));

            if (result != null)
                return result;

            productRepository.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(productRepository.GetAll(), Messages.ProductAdded);
        }

        private IResult CheckIfProductCountCategoryCorrent(int CategoryId)
        {
            var result = productRepository.GetAll(p => p.CategoryId == CategoryId).Count;
            if (result >= 15)
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = productRepository.GetAll(p => p.ProductName == productName).Any();
            if (result)
                return new ErrorResult(Messages.ProductNameAlreadyExixts);
            return new SuccessResult();
        }
    }
}
