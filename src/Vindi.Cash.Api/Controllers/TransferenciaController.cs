using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vindi.Cash.Api.Application.Members.Commands;

namespace Vindi.Cash.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferenciaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransferenciaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Criar")]
        public async Task<IResult> Transfer([FromBody] CriarTransferenciaCommand command)
        {
            return Results.Ok(await _mediator.Send(command));
        }
    }
}
