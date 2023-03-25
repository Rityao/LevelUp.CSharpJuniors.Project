using Microsoft.EntityFrameworkCore;
using MyStore.API.DAL.Entities;

namespace MyStore.API.DAL
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductsDbContext _dbContext; // слепок БД

        public ProductsRepository(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(ProductEntity productEntity)
        {
            await _dbContext.Products!.AddAsync(productEntity);
            await _dbContext.SaveChangesAsync();
        }

        public Task<IEnumerable<ProductEntity>> GetAllProducts()
        {
            return Task.FromResult<IEnumerable<ProductEntity>>(_dbContext.Products!.ToList());
        }

        public Task<ProductEntity?> GetProduct(Guid id)
        {
            return _dbContext.Products!.FirstOrDefaultAsync(e => e.Id.Equals(id));
        }
    }
}
