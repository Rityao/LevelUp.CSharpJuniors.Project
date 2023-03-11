using LevelUp.CSharpJuniors.Project.DAL.Entities;
using System.Threading.Tasks;

namespace LevelUp.CSharpJuniors.Project.DAL
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<ProductEntity>> GetAllProducts();
      //  public Task<ProductEntity> GetProduct(Guid id);
    }
}