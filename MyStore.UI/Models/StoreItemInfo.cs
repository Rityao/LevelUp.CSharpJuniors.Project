namespace MyStore.UI.Models
{
    public sealed record StoreItemInfo
    {
        public Guid Id { get; init; }
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Price { get; set; }
    }
}