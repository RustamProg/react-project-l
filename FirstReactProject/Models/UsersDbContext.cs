using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace FirstReactProject.Models
{
    public class UsersDbContext: DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options): base(options)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
    }
}