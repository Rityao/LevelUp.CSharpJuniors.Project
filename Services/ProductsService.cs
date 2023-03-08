using LevelUp.CSharpJuniors.Project.DAL;
using LevelUp.CSharpJuniors.Project.Models;
using LevelUp.CSharpJuniors.Project.Services;

namespace LevelUp.CSharpJuniors.Project.Services
{
    public sealed class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<IEnumerable<ProductItem>> GetProducts()
        {
            var entities = await _productsRepository.GetAllProducts();
            return entities.Select(e => new ProductItem(e.Id, e.Name, e.Description));
        }
    }
}