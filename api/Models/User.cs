using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public void SetPassword(string password)
        {
            var hasher = new PasswordHasher<User>();
            Password = hasher.HashPassword(this, password);
        }

        public bool CheckPassword(string password)
        {
            var hasher = new PasswordHasher<User>();
            return hasher.VerifyHashedPassword(this, this.Password, password) == PasswordVerificationResult.Success;
        }
    }
}
