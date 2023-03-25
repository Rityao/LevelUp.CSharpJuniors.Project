using MyStore.API.DAL;
using MyStore.API.DAL.Entities;
using MyStore.API.Models;

namespace MyStore.API.Services
{
    public sealed class ProductsService : IProductsService
    {
        private readonly IProductsRepository? _productsRepository;
        private readonly IProductsRepository? _productItem;
        private readonly string? id;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public ProductsService(IProductsRepository productsRepository, string id)
        {
            this.id = id;
            _productItem = productsRepository;
        }
        public async Task<IEnumerable<ProductItem>> GetProducts()
        {
            var entities = await _productsRepository.GetAllProducts();
            return entities.Select(ProductItem.FromEntity);
        }
        public async Task<ProductItem?> GetProductById(Guid id)
        {
            var entity = await _productsRepository.GetProduct(id);
            return entity == null ? null : ProductItem.FromEntity(entity);
        }

        public async Task AddProducts(ProductItem productItem)
        {
            var entity = new ProductEntity
            {
                Id = productItem.Id,
                Name = productItem.Name,
                Description = productItem.Description,
                CategoryId = productItem.CategoryId
            };
            await _productsRepository.Create(entity);
        }
    }
}