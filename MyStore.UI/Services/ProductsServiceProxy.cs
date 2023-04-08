using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using MyStore.UI.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace MyStore.UI.Services
{
    public sealed class ProductsServiceProxy : IProductsServiceProxy
    {
        private readonly HttpClient _client;

        private readonly Endpoints _endpoints;

        private readonly NavigationManager _navigationManager;


        public ProductsServiceProxy(HttpClient client, IOptions<Endpoints> endpoints, NavigationManager navigationManager)
        {
            _client = client;
            _endpoints = endpoints.Value;
            _navigationManager = navigationManager;
        }

        public async Task DeleteProduct(Guid id)
        {
            var requestUri = $"{_endpoints.BaseUrl}{_endpoints.DeleteProduct}";
            requestUri = string.Format(requestUri, id);
            await _client.DeleteAsync(requestUri);
            _navigationManager.NavigateTo("/nomenclature");

        }

        public async Task<IEnumerable<ProductItem>> GetAllProducts()
        {
            var requestUri = $"{_endpoints.BaseUrl}{_endpoints.GetAllProducts}";
            var items = await MakeGet<IEnumerable<ProductItem>>(requestUri)
                        ?? Enumerable.Empty<ProductItem>();

            return items;
        }

        public async Task<ProductItem> GetProductById(Guid id)
        {
            var requestUri = $"{_endpoints.BaseUrl}{_endpoints.GetProductById}";
            requestUri = string.Format(requestUri, id);
            var item = await MakeGet<ProductItem>(requestUri);

            return item!;
        }


        private async Task<T?> MakeGet<T>(string requestUri)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUri)
            };

            using var response = await _client.SendAsync(request);
            var result = await response.Content.ReadFromJsonAsync<T>();

            return result;
        }

        public async Task UpdateProduct(StoreItemInfo storeItemInfo)
        {
            var requestUri = $"{_endpoints.BaseUrl}{_endpoints.UpdateProduct}";
            var uri = string.Format(requestUri);
            ProductItem updatedProduct = new()
            {
                Name = storeItemInfo.Name,
                Description = storeItemInfo.Description,
                Id = storeItemInfo.Id,
                CategoryId = Guid.NewGuid(),
                Price = decimal.Parse(storeItemInfo.Price)
            };
            var prod = JsonSerializer.Serialize(updatedProduct);
            var requestContent = new StringContent(prod, Encoding.UTF8, "application/json");
            
            var response = await _client.PutAsync(uri, requestContent);
            response.EnsureSuccessStatusCode();

            _navigationManager.NavigateTo("/nomenclature");
        }

        public async Task AddProduct(StoreItemInfo storeItemInfo)
        {
            var requestUri = $"{_endpoints.BaseUrl}{_endpoints.AddProduct}";
            var uri = string.Format(requestUri);
            ProductItem newProduct = new()
            {
                Name = storeItemInfo.Name,
                Description = storeItemInfo.Description,
                Id = Guid.NewGuid(),
                CategoryId = Guid.NewGuid(),
                Price = decimal.Parse(storeItemInfo.Price)
            };
            var prod = JsonSerializer.Serialize(newProduct);
            var requestContent = new StringContent(prod, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(uri, requestContent);
            response.EnsureSuccessStatusCode();

            _navigationManager.NavigateTo("/nomenclature");
        }
    }
}
