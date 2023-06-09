﻿using LevelUp.CSharpJuniors.Project.DAL;
using LevelUp.CSharpJuniors.Project.Models;
using LevelUp.CSharpJuniors.Project.Services;

namespace LevelUp.CSharpJuniors.Project.Services
{
    public sealed class ProductsService : IProductsService
    {
        private readonly IProductsRepository ? _productsRepository;

        private Dictionary<Guid, ProductItem> _products = new();
        public ProductsService()
        {
            InitProduct();
        }

        private void InitProduct()
        {
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            var guid3 = Guid.NewGuid();
            
            _products = new Dictionary<Guid, ProductItem>
            {
                { guid1, new ProductItem(guid1, "Печенье", "Сдобное")},
                { guid2, new ProductItem(guid1, "Мармеладки", "Мишки")},
                { guid3, new ProductItem(guid1, "Шоколад", "С орешками")},
            };
        }

        /*  public ProductsService(IProductsRepository productsRepository)
          {
              _productsRepository = productsRepository;
          }

          public async Task<ProductItem> GetProductById(Guid id)
          {
              var entity = await _productsRepository.GetProduct(id);
              return entity.Select(e => new ProductItem(id, e.Name, e.Description));
          }
         */
        public async Task<IEnumerable<ProductItem>> GetProducts()
        {
            return _products.Values;
         //   var entities = await _productsRepository.GetAllProducts();
          //  return entities.Select(e => new ProductItem(e.Id, e.Name, e.Description));
        }

        public async Task<ProductItem> GetProductById(string id)
        {
            Guid guid = Guid.Parse(id);
            return _products[guid];
        }
    }
}