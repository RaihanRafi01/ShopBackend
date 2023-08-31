using BLL.DTO;
using DAL.Repository;
using DAL.Repository.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private BLL.Services.UserService _BLL;
        public UserController() 
        {
            _BLL = new BLL.Services.UserService();

        }
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUser()
        {
            return _BLL.GetAllUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var data = _BLL.GetUserById(id);
            if (data == null)
            {
                return NotFound("Invalid Id");
            }
            return Ok(data);
        }
        [HttpPost]
        public void PostUser(UserDTO userDTO)
        {
            _BLL.postUser(userDTO);
        }

        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            _BLL.DeleteUser(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserDTO userDTO)
        {
           var data = _BLL.UpdateUser(id, userDTO);

            if (data == null)
            {
                return NotFound("Invalid Id");
            }
            return Ok(data);
        }
    }
}
