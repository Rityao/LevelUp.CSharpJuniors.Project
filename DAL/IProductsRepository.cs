using LevelUp.CSharpJuniors.Project.DAL.Entities;

namespace LevelUp.CSharpJuniors.Project.DAL
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<ProductEntity>> GetAllProducts();
    }
}