namespace MyStore.UI.Models
{
    public sealed record StoreItemInfo
    {
        public StoreItemInfo(Guid id, string name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }   = string.Empty;
        public string? Description { get; set; }

    }

}
