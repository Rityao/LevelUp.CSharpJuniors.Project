using LevelUp.CSharpJuniors.Project.Models;
// документ, чтобы понять что класс делает, контракт
namespace LevelUp.CSharpJuniors.Project.Services
{
    public interface IProductsService
    {
        Task<ProductItem> GetProductById(string id);
        Task<IEnumerable<ProductItem>> GetProducts();
    }
}