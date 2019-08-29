using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechDemo.Auth.API.Services;
using TechDemo.Auth.API.ViewModels;

namespace TechDemo.Auth.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserViewModel userVM)
        {
            var user = await _userService.Authenticate(userVM);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);

        }
    }
}
