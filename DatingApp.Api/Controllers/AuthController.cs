using System.Threading.Tasks;
using DatingApp.Api.Data;
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
        public async Task<IActionResult> Register(string username, string password)
        {
            //validate request

            username = username.ToLower();

            if(await _repository.UserExists(username)) return BadRequest("username already exists!");

            var userToCreate = new User
            {
                Username = username 
            };

            var createdUser = await _repository.Register(userToCreate, password);

            return StatusCode(201);

        }
    }
}