using BlogWeb.Dtos.Users;
using BlogWeb.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserRepository userRepo) : ControllerBase
    {
        [HttpPost]
        [Route("auth")]
        public async Task<ActionResult> AuthenticateUser([FromBody] LoginUserDto loginUser)
        {
            var accessToken = await userRepo.LoginUser(loginUser);
            if (accessToken == null)
                return Unauthorized();

            else return Ok(accessToken);
        }
    }
}
