using LevelUp.CSharpJuniors.Project.Models;
using LevelUp.CSharpJuniors.Project.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LevelUp.CSharpJuniors.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<ProductItem>> GetProducts()
        {
            var products = _productsService.GetProducts();
            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ProductItem>> Get(Guid id)
        {
            var product = _productsService.GetProductById(id);
            return Ok(product);
        }
    }
}
