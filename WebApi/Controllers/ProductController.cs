using Business.Abstract;
using Core.Utilities.Paging;
using Entities.Concrete.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Ctor
        private readonly IProductManager productManager;
        public ProductController(IProductManager productManager)
        {
            this.productManager = productManager;
        }
        #endregion

        [HttpPost("Add")]
        public IActionResult Add([FromBody] Product product)
        {
            return Ok(productManager.Add(product));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(productManager.GetAll());
        }


        [HttpGet("PaginateAll")]
        public IActionResult PaginateAll([FromQuery] Pageable? pageable)
        {
            return Ok(productManager.PaginateAll(pageable));
        }

        [HttpGet("PaginateAllReturnList")]
        public IActionResult PaginateAllReturnList([FromQuery] Pageable? pageable)
        {
            return Ok(productManager.PaginateAllReturnList(pageable));
        }
    }
}
