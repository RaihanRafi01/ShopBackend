using BLL.DTO;
using DAL.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        
        private BLL.Services.UserService _BLL;
        private IConfiguration _config;
        public LoginController(IConfiguration configuration)
        {
            _config = configuration;
            _BLL = new BLL.Services.UserService();
        }
        private User AuthenticateUser(User user)
        {
            
            var data = _BLL.Auth(user.Name, user.Password);
            User _user = null;
            if (data != false)
            {
                _user = new User { Name = user.Name };
            }
            return _user;

           
        }

        private string GenerateToken(User user)
        {
            var secutitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(secutitykey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        
        [HttpPost]
        public IActionResult Login(User user)
        {
            IActionResult responce = Unauthorized();
            var user_ = AuthenticateUser(user);
            if (user_ != null)
            {
                var token = GenerateToken(user_);
                responce = Ok(new { token = token });
            }
            return responce;
        }
    }
}
