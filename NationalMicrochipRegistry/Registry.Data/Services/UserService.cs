using System.Collections.Generic;
using System.Linq;
using Registry.Data.Models;

namespace Registry.Data.Services
{
    /// <summary>
    /// Provides services related to user management.
    /// </summary>
    public class UserService
    {
        private readonly RegistryDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public UserService(RegistryDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="user">The user to add.</param>
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        /// <summary>
        /// Authenticates a user by matching username and password hash.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="passwordHash">The hashed password of the user.</param>
        /// <returns>The authenticated user or null if not found.</returns>
        public User Authenticate(string username, string passwordHash)
        {
            return _context.Users.FirstOrDefault(u =>
                u.Username == username && u.PasswordHash == passwordHash);
        }

        /// <summary>
        /// Retrieves all users in the system.
        /// </summary>
        /// <returns>A list of all users.</returns>
        public List<User> GetAllUsers() => _context.Users.ToList();
    }
}
