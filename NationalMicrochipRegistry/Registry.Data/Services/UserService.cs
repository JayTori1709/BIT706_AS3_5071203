// UserService.cs:
using System.Collections.Generic;
using System.Linq;
using Registry.Data.Models;

namespace Registry.Data.Services
{
    public class UserService
    {
        private readonly RegistryDbContext _context;

        public UserService(RegistryDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User Authenticate(string username, string passwordHash)
        {
            return _context.Users.FirstOrDefault(u =>
                u.Username == username && u.PasswordHash == passwordHash);
        }

        public List<User> GetAllUsers() => _context.Users.ToList();

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
