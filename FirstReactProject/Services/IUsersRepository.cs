using System.Collections.Generic;
using FirstReactProject.Models;

namespace FirstReactProject.Services
{
    public interface IUsersRepository
    {
        User GetUserById(int id);
        List<User> GetUsersByCountry(string countryName);
        List<User> GetUsersByCity(string cityName);
        List<User> GetAllUsers();
        List<User> GetByLocation(string country, string city);
    }
}