using APICreateUser.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICreateUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TUser : ControllerBase
    {
        private readonly IUserRepository _repogitoty;

        public TUser(IUserRepository repository)
        {
           _repogitoty = repository;
        }
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] DTO.RegisterUserDto registerUserDto)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            await _repogitoty.RegisterUser(registerUserDto, ip);
            return Ok("User registered successfully");
        }
        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] Models.TblUser tblUser ,int id)
        {
            var user = await _repogitoty.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            await _repogitoty.UpdateUser(tblUser);
            return Ok("User updated successfully");
        }
        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _repogitoty.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repogitoty.GetAllUsers();
            return Ok(users);
        }
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _repogitoty.DeleteUser(id);
            return Ok("User deleted successfully");
        }
    }
}
