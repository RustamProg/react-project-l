using System.Collections.Generic;
using System.Linq;
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
            var dbUser = _context.Users.FirstOrDefault(o => o.id == id);
            return dbUser;
        }

        public List<User> GetUsersByCountry(string countryName)
        {
            var dbUsers = _context.Users.Where(o => o.locationCountry == countryName).ToList();
            return dbUsers;
        }

        public List<User> GetUsersByCity(string cityName)
        {
            var dbUsers = _context.Users.Where(o => o.locationCity == cityName).ToList();
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
    }
}