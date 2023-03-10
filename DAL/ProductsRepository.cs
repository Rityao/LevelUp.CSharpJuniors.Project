using LevelUp.CSharpJuniors.Project.DAL.Entities;

namespace LevelUp.CSharpJuniors.Project.DAL
{
    public sealed class ProductsRepository : IProductsRepository
    {
        private readonly ProductsDbContext _dbContext;

        public ProductsRepository(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<ProductEntity>> GetAllProducts()
        {
            return Task.FromResult(Enumerable.Empty<ProductEntity>());
        }

        public Task<ProductEntity> GetProduct(Guid id)
        {
            return Task.FromResult(result: productEntity);
        }
    }
}

