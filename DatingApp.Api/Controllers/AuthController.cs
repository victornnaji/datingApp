using System.Threading.Tasks;
using DatingApp.Api.Data;
using DatingApp.Api.DTOs;
using DatingApp.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        public AuthController(IAuthRepository repository)
        {
            _repository = repository;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDTO userForRegister)
        {
            //validate request

            userForRegister.username = userForRegister.username.ToLower();

            if(await _repository.UserExists(userForRegister.username)) return BadRequest("username already exists!");

            var userToCreate = new User
            {
                Username = userForRegister.username 
            };

            var createdUser = await _repository.Register(userToCreate, userForRegister.password);

            return StatusCode(201);

        }
    }
}