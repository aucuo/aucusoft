using api.Context;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api
{
    public class UserService
    {
        private readonly MyDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(MyDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public void AddUser(string username, string password)
        {
            var user = new User
            {
                Username = username,
                Password = _passwordHasher.HashPassword(null, password)
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }

}
