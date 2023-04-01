﻿using MyStore.UI.Models;
namespace MyStore.UI.Services
{
    public interface IProductsServiceProxy
    {
        Task<IEnumerable<ProductItem>> GetAllProducts();
        Task<ProductItem> GetProductById(Guid id);
        Task DeleteProducts(Guid id);
        Task UpdateProducts(ProductItem productItem);
    } 
}
