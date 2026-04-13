using Microsoft.EntityFrameworkCore;
using UserExplorer.Core.Domain.Entities;

namespace UserExplorer.Infrastructure.Persistence.Context
{
    public class UserExplorerContext : DbContext
    {
        public UserExplorerContext(DbContextOptions<UserExplorerContext> opt) : base(opt){ }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserExplorerContext).Assembly);
        }
    }
}
