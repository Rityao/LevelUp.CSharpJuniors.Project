using LevelUp.CSharpJuniors.Project.Models;

namespace LevelUp.CSharpJuniors.Project.Services
{
    public interface IProductsService
    {
        Task<object> GetProductById(int id);
        Task<IEnumerable<ProductItem>> GetProducts();
    }
}