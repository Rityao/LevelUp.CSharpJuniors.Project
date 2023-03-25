using MyStore.API.DAL.Entities;

namespace MyStore.API.DAL
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<ProductEntity>> GetAllProducts();
        public Task<ProductEntity?> GetProduct(Guid id);
        public Task Create(ProductEntity productEntity);
    }
}