using Banca.Application.Features.Accounts.Commands.CreateAccounts;
using Banca.Application.Features.Accounts.Commands.DeleteAccounts;
using Banca.Application.Features.Accounts.Commands.UpdateAccounts;
using Banca.Application.Features.Accounts.Queries.GetAccountById;
using Banca.Application.Features.Accounts.Queries.GetAllAccounts;
using Banca.Infrastructure.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Banca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseApiController
    {
        [HttpGet("GetByIdAccount")]
        [ServiceFilter(typeof(JwtAuthorizationFilter))]
        public async Task<IActionResult> GetByIdAccount([FromBody] GetAccountByIdQuery Query)
        {
            var result = await Mediator.Send(Query);
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpGet("GetAllAccount")]
        [ServiceFilter(typeof(JwtAuthorizationFilter))]
        public async Task<IActionResult> GetAllAccount([FromBody] GetAllAccountQuery Query)
        {
            var result = await Mediator.Send(Query);
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpPost("CreateAccount")]
        [ServiceFilter(typeof(JwtAuthorizationFilter))]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand command)
        {
            var result = await Mediator.Send(command);
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpPut("UpdateAccount")]
        [ServiceFilter(typeof(JwtAuthorizationFilter))]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountCommand command)
        {
            var result = await Mediator.Send(command);
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpDelete("DeleteAccount")]
        [ServiceFilter(typeof(JwtAuthorizationFilter))]
        public async Task<IActionResult> DeleteAccount([FromBody] DeleteAccountCommand command)
        {
            var result = await Mediator.Send(command);
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
        }
    }
}
