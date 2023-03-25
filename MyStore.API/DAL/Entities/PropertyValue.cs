namespace MyStore.API.DAL.Entities
{
    public sealed record PropertyValue(Guid Id, Guid PropertyId, Guid ProductId, string Value);
}