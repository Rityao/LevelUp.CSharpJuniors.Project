namespace MyStore.UI.Models;
public sealed record Endpoints
{
    public string BaseUrl { get; init; } = string.Empty;
    public string GetAllProducts { get; init; } = string.Empty;
    public string GetProductById { get; init; } = string.Empty;
    public string DeleteProduct { get; init; } = string.Empty;
    public string UpdateProduct { get; init; } = string.Empty;
    public string AddProduct { get; init; } = string.Empty;
}