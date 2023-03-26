using MyStore.API.Models;
using MyStore.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStore.API.Controllers
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
        public async Task<ActionResult<IEnumerable<ProductItem>>> GetProducts()
        {
            var products = await _productsService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProductItem>>> GetProductById([FromRoute] Guid id)
        {
            var product = await _productsService.GetProductById(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct(ProductItem productItem)
        {
            await _productsService.AddProducts(productItem);
            return Ok();
        }

        [HttpDelete("del")]
        public async Task<IActionResult> DelProduct(Guid id)
        {
            await _productsService.DeleteProducts(id);
            return Ok();
        }

        [HttpPut("upd")]
        public async Task<IActionResult> UpdateProduct(ProductItem productItem)
        {
            await _productsService.UpdateProducts(productItem);
            return Ok();
        }
    }
}