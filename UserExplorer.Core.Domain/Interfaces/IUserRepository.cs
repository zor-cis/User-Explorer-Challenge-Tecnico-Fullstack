using UserExplorer.Core.Domain.Entities;

namespace UserExplorer.Core.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<List<User>> GetAllUsersAsync();
        IQueryable<User> GetUsersQuery();
        Task<User?> GetUserByIdAsync(int id);
    }
}