using MyStore.UI.Models;
namespace MyStore.UI.Services
{
    public interface IProductsServiceProxy
    {
        Task<IEnumerable<ProductItem>> GetAllProducts();
        Task<ProductItem> GetProductById(Guid id);
        Task DeleteProduct(Guid id);
        Task UpdateProduct(StoreItemInfo storeItemInfo);
        Task AddProduct(StoreItemInfo storeItemInfo);
    } 
}
