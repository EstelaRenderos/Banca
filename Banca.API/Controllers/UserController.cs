using Microsoft.AspNetCore.Mvc;
using Banca.Application.DTOs.User;
using Banca.Application.Features.User.Commands.CreateUser;

namespace Banca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseApiController
    {

        [HttpPost("CreateUser")]
        //[ServiceFilter(typeof(JwtAuthorizationFilter))]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var command = new CreateUserCommand { UserRequest = request };
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}