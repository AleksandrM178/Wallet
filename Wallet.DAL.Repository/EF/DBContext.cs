using Microsoft.EntityFrameworkCore;
using Wallet.Common.Entities.User.DB;

namespace Wallet.DAL.Repository.EF
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
            
        }
    }
}
