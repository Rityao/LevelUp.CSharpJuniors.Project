using LevelUp.CSharpJuniors.Project.DAL;
using LevelUp.CSharpJuniors.Project.Models;
using LevelUp.CSharpJuniors.Project.Services;

namespace LevelUp.CSharpJuniors.Project.Services
{
    public sealed class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        private readonly Dictionary<Guid, ProductItem> _products = new();
        public ProductsService()
        {
            InitProduct();
        }

        private void InitProduct()
        {
            throw new NotImplementedException();
        }

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<ProductItem> GetProductById(Guid id)
        {
            var entity = await _productsRepository.GetProduct(id);
            return entity.Select(e => new ProductItem(id, e.Name, e.Description));
        }

        public async Task<IEnumerable<ProductItem>> GetProducts()
        {
            var entities = await _productsRepository.GetAllProducts();
            return entities.Select(e => new ProductItem(e.Id, e.Name, e.Description));
        }
    }
}