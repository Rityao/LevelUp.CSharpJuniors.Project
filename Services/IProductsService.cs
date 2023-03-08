using LevelUp.CSharpJuniors.Project.Models;

namespace LevelUp.CSharpJuniors.Project.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductItem>> GetProducts();
    }
}