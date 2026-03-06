using APICreateUser.DTO;
using APICreateUser.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
        {
            var result = await _repogitoty.RegisterUser(registerUserDto);

            

            return Ok("User registered successfully");
        }
        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser( [FromBody] UpdateUser update,int id)
        {
            try
            {
                await _repogitoty.UpdateUser(update,id);
                return Ok(new { message = "User updated successfully" });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
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
        [HttpGet("GetAlIps")]
        public async Task<IActionResult> GetAlIps()
        {
            var users = await _repogitoty.GetUserIPs();
            return Ok(users);
        }
    }
}
