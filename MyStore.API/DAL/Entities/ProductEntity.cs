using MyStore.API.Models;

namespace MyStore.API.DAL.Entities
{
    public sealed record ProductEntity
    {
        public Guid Id { get; init; }

        public Guid CategoryId { get; init; }

        public string Name { get; init; } = string.Empty;

        public string? Description { get; init; }
        public bool IsActive { get; init; }

        public IEnumerable<PropertyValue> Properties { get; set; } = Enumerable.Empty<PropertyValue>();

    }
}
