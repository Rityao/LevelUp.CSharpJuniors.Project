namespace LevelUp.CSharpJuniors.Project.DAL.Entities
{
    public sealed record PropertyValue(Guid Id, Guid PropertyId, Guid ProductId, string Value);
}
