using Microsoft.EntityFrameworkCore;
using UserExplorer.Core.Domain.Entities;
using UserExplorer.Core.Domain.Interfaces;
using UserExplorer.Infrastructure.Persistence.Context;

namespace UserExplorer.Infrastructure.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserExplorerContext _context;

        public UserRepository(UserExplorerContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(User user)
        {
            await _context.Set<User>().AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Set<User>().FindAsync(id);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Set<User>().ToListAsync();
        }

        public IQueryable<User> GetUsersQuery()
        {
            return _context.Set<User>().AsQueryable();

        }
    }
}
