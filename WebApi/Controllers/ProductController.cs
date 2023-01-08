using Business.Abstract;
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

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(productManager.GetAll());
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] Product product)
        {
            return Ok(productManager.Add(product));
        }
    }
}
