using MyStore.API.DAL.Entities;

namespace MyStore.API.Models;
public sealed record User(Guid Id, string Name, bool IsAdmin)
{
    public static User FromEntity(UserEntity userEntity)
    {
        return new User(userEntity.Id, userEntity.Name, userEntity.IsAdmin);
    }
}