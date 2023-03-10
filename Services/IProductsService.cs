using LevelUp.CSharpJuniors.Project.Models;
// документ, чтобы понять что класс делает
namespace LevelUp.CSharpJuniors.Project.Services
{
    public interface IProductsService
    {
        Task<ProductItem> GetProductById(Guid id);
        Task<IEnumerable<ProductItem>> GetProducts();
    }
}