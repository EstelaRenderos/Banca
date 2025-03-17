using Banca.Application.Features.Transactions.Commands.CreateTransactions;
using Banca.Application.Features.Transactions.Commands.DeleteTransactions;
using Banca.Application.Features.Transactions.Commands.UpdateTransactions;
using Banca.Application.Features.Transactions.Queries.GetTransactionById;
using Banca.Application.Features.Transactions.Queries.GetAllTransactions;
using Banca.Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Banca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : BaseApiController
    {

        [HttpGet("GetByIdTransaction")]
        [ServiceFilter(typeof(JwtAuthorizationFilter))]
        public async Task<IActionResult> GetByIdTransaction([FromBody] GetTransactionByIdQuery Query)
        {
            var result = await Mediator.Send(Query);
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpGet("GetAllTransaction")]
        [ServiceFilter(typeof(JwtAuthorizationFilter))]
        public async Task<IActionResult> GetAllTransaction([FromBody] GetAllTransactionsQuery Query)
        {
            var result = await Mediator.Send(Query);
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpPost("CreateTransaction")]
        [ServiceFilter(typeof(JwtAuthorizationFilter))]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionCommand command)
        {
            var result = await Mediator.Send(command);
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpPut("UpdateTransaction")]
        [ServiceFilter(typeof(JwtAuthorizationFilter))]
        public async Task<IActionResult> UpdateTransaction([FromBody] UpdateTransactionCommand command)
        {
            var result = await Mediator.Send(command);
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpDelete("DeleteTransaction")]
        [ServiceFilter(typeof(JwtAuthorizationFilter))]
        public async Task<IActionResult> DeleteTransaction([FromBody] DeleteTransactionCommand command)
        {
            var result = await Mediator.Send(command);
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
        }
    }
}
