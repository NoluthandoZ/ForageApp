using Forage.Contracts;
using Forage.DTOs;
using Forage.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forage.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userRepo.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "userById")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            try
            {
                var user = await _userRepo.GetUser(id);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                var user = await _userRepo.GetUserByEmail(loginDto.EmailAddress);
                if (user == null)
                    return NotFound();

                if (user.Password == loginDto.Password)
                    return Ok(user);

                return StatusCode(401, "You are unauthorized!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(User user)
        {
            try
            {
                var created = await _userRepo.AddUser(user);

                if (created)
                return Ok("User created");
                return BadRequest("Unable to create user");
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(User user)
        {
            try
            {
                await _userRepo.UpdateUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                var deleted = await _userRepo.DeleteUser(id);
                if (deleted)
                {
                    return StatusCode(204, "Record Deleted");
                }

                return BadRequest("Record not found");
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);

            }
        }
    }
}
