using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstReactProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstReactProject.Services
{
    public class UsersRepository: IUsersRepository
    {
        private readonly UsersDbContext _context;

        public UsersRepository(UsersDbContext context)
        {
            _context = context;
        }
        
        public User GetUserById(int id)
        {
            var dbUser = _context.Users.Include(x => x.Address).FirstOrDefault(o => o.id == id);
            dbUser.Roles = _context.UserRoles.Include(x => x.Role).Where(x => x.UserId == dbUser.id).Select(x => x.Role).ToList();
            return dbUser;
        }

        public List<User> GetUsersByCountry(string countryName)
        {
            var dbUsers = _context.Users.Where(o => o.locationCountry == countryName).ToList();
            return dbUsers;
        }

        public List<User> GetUsersByCity(string cityName)
        {
            var dbUsers = _context.Users.Include(x => x.Address).Where(o => o.Address.City == cityName).ToList();
            return dbUsers;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public List<User> GetByLocation(string country, string city)
        {
            var dbUsers = _context.Users.Where(o => o.locationCountry == country && o.locationCity == city).ToList();
            return dbUsers;
        }

        public async Task InsertUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public void AddRole(Role role)
        {
            _context.Roles.Add(role);
        }

        public void AddUserRoles(int userId, int roleId)
        {
            _context.UserRoles.Add(new UserRoles()
            {
                UserId = userId,
                RoleId = roleId
            });
        }
    }
}