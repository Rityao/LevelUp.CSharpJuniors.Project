using MyStore.API.DAL.Entities;

namespace MyStore.API.DAL
{
    public interface IUsersRepository
    {
        public Task<IEnumerable<UserEntity>> GetAllUsers();
        public Task<UserEntity?> GetUserById(Guid id);
        public Task Create(UserEntity userEntity);
    }
}
