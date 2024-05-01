using api.Context;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Controllers
{
    [ApiController]
    [Route("aucusoft/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IConfiguration _configuration;

        public UserController(MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register(UserDto userDto)
        {
            var user = new User { Username = userDto.Username };
            if (userDto.Password == null) return NotFound();

            user.SetPassword(userDto.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("check")]
        public IActionResult Check()
        {
            return Ok(new { Message = "Authorized" });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(UserDto userDto)
        {
            if (userDto.Password == null) return NotFound();
            var user = _context.Users.SingleOrDefault(u => u.Username == userDto.Username);
            if (user == null || !user.CheckPassword(userDto.Password))
                return Unauthorized("Invalid data");

            var token = GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

        private string? GenerateJwtToken(User user)
        {
            var key = _configuration["Jwt:Key"];
            if (user.Username == null || key == null) return null;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", user.Id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
