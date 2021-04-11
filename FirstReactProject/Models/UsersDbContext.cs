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
    }
}