using Banca.Application.Features.Auth.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Banca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseApiController
    {
       
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Application.DTOs.LoginRequest request)
        {
            try
            {
                var command = new LoginCommand { LoginRequest = request };
                var result = await Mediator.Send(command);
                return Ok(result);  
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new { message = "Usuario o contraseña incorrectos" });
            }
        }
    }
}
