﻿using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using MyStore.UI.Models;

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

        public Task AddProduct(ProductItem productItem)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteProduct(Guid id)
        {
            var requestUri = $"{_endpoints.BaseUrl}{_endpoints.DeleteProduct}";
            requestUri = string.Format(requestUri, id);
            
            await MakeDelete<ProductItem>(requestUri);
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

        public async Task UpdateProduct(ProductItem productItem)
        {
            var requestUri = $"{_endpoints.BaseUrl}{_endpoints.UpdateProduct}";
            requestUri = string.Format(requestUri);
            await MakePost<ProductItem>(requestUri);
            _navigationManager.NavigateTo("/nomenclature");
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

        private async Task<T?> MakeDelete<T>(string requestUri)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(requestUri)
            };

            using var response = await _client.SendAsync(request);
            var result = await response.Content.ReadFromJsonAsync<T>();

            return result;
        }

        private async Task<T?> MakePost<T>(string requestUri)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(requestUri)
            };

            using var response = await _client.SendAsync(request);
            var result = await response.Content.ReadFromJsonAsync<T>();

            return result;
        }
    }
}
