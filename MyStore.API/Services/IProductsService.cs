using MyStore.API.Models;
// документ, чтобы понять что класс делает, контракт
namespace MyStore.API.Services
{
    public interface IProductsService
    {
        Task<ProductItem?> GetProductById(Guid id);
        Task<IEnumerable<ProductItem>> GetProducts();
        Task AddProducts(ProductItem productItem);
        Task DeleteProducts(Guid id);
        Task UpdateProducts(ProductItem productItem);
    }
}