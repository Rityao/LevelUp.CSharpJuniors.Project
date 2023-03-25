using MyStore.API.Models;

namespace MyStore.API.DAL.Entities
{
    public sealed record UserEntity
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public bool IsAdmin { get; init; }
    }
}
