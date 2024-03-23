using Dev_space.Models;
using Microsoft.EntityFrameworkCore;

namespace Dev_space.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option):base(option)
        {

        }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Post> posts { get; set; }  
    }
}
