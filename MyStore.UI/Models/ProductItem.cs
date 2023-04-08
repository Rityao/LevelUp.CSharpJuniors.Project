namespace MyStore.UI.Models
{
    public sealed record ProductItem
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }

}
}
