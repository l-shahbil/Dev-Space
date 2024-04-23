using Dev_space.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Dev_space.Data
{
    public class AppDbContext:IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> option):base(option)
        {

        }
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<Post> posts { get; set; }  
        public DbSet<Archive> archives { get; set; }
        public DbSet<Code> codes { get; set; }
        public DbSet<Commint> commints { get; set; }
        public DbSet<Friend > friends { get; set; }
        public DbSet<Img> imgs { get; set; }
        public DbSet<Like> likes { get; set; }
        public DbSet<Link> links { get; set; }
        public DbSet<Tag> tags { get; set; }
    }
}
