using Banca.Application.Features.Transfers.Queries.GetTransferById;
using Banca.Application.Features.Transfers.Queries.GetAllTransfers;
using Banca.Infrastructure.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Banca.Application.Features.Transfers.Commands.CreateTransfer;
using Banca.Application.Features.Transfers.Commands.UpdateTransfer;
using Banca.Application.Features.Transfers.Commands.DeleteTransfer;

namespace Banca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : BaseApiController
    {

        [HttpGet("GetByIdTransfer")]
        [ServiceFilter(typeof(JwtAuthorizationFilter))]
        public async Task<IActionResult> GetByIdTransfer([FromBody] GetTransferByIdQuery Query)
        {
            var result = await Mediator.Send(Query);
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpGet("GetAllTransfer")]
        [ServiceFilter(typeof(JwtAuthorizationFilter))]
        public async Task<IActionResult> GetAllTransfer([FromBody] GetAllTransfersQuery Query)
        {
            var result = await Mediator.Send(Query);
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpPost("CreateTransfer")]
        [ServiceFilter(typeof(JwtAuthorizationFilter))]
        public async Task<IActionResult> CreateTransfer([FromBody] CreateTransferCommand command)
        {
            var result = await Mediator.Send(command);
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpPut("UpdateTransfer")]
        [ServiceFilter(typeof(JwtAuthorizationFilter))]
        public async Task<IActionResult> UpdateTransfer([FromBody] UpdateTransferCommand command)
        {
            var result = await Mediator.Send(command);
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpDelete("DeleteTransfer")]
        [ServiceFilter(typeof(JwtAuthorizationFilter))]
        public async Task<IActionResult> DeleteTransfer([FromBody] DeleteTransferCommand command)
        {
            var result = await Mediator.Send(command);
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
        }
    }
}
