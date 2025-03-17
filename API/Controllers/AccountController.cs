using Banca.Application.Features.Accounts.Commands;
using Banca.Application.Features.Accounts.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountCommand command)
        {
            var accountId = await _mediator.Send(command);
            return Ok(accountId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            var query = new GetAccountByIdQuery { Id = id };
            var account = await _mediator.Send(query);
            return Ok(account);
        }
    }
}
