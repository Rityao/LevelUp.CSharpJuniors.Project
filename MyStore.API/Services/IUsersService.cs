using MyStore.API.Models;

namespace MyStore.API.Services
{
    public interface IUsersService
    {
        Task<User?> GetUserById(Guid id);
        Task<IEnumerable<User>> GetUsers();
        Task AddUsers(User user);
    }
}