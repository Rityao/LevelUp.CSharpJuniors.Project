using Microsoft.Extensions.Options;
using MyStore.UI.Models;

namespace MyStore.UI.Services
{
    public sealed class ProductsServiceProxy : IProductsServiceProxy
    {
        private readonly HttpClient _client;

        private readonly Endpoints _endpoints;

        public ProductsServiceProxy(HttpClient client, IOptions<Endpoints> endpoints)
        {
            _client = client;
            _endpoints = endpoints.Value;
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
    }
}
