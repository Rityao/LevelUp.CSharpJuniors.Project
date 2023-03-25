using MyStore.API.DAL;
using MyStore.API.DAL.Entities;
using MyStore.API.Models;

namespace MyStore.API.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository? _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task AddUsers(User user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                IsAdmin = user.IsAdmin
            };
            await _usersRepository.Create(userEntity);
        }

        public async Task<User?> GetUserById(Guid id)
        {
            var entity = await _usersRepository.GetUserById(id);
            return entity == null ? null : User.FromEntity(entity);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var entities = await _usersRepository.GetAllUsers();
            return entities.Select(User.FromEntity);
        }
    }
}
