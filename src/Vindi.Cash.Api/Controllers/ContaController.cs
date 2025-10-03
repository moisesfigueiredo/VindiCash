using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vindi.Cash.Api.Application.Members.Commands;
using Vindi.Cash.Api.Application.Members.Queries;

namespace Vindi.Cash.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Cadastrar")]
        public async Task<IResult> Create([FromBody] CriarContaCommand command)
        {
            return Results.Ok(await _mediator.Send(command));
        }

        [HttpGet("ObterTodas")]
        public async Task<IResult> GetAll([FromQuery] ObterTodasContasQuery query)
        {
            return Results.Ok(await _mediator.Send(query));
        }

        [HttpGet("ObterPorId")]
        public async Task<IResult> GetById([FromQuery] ObterContaPorIdQuery query)
        {
            return Results.Ok(await _mediator.Send(query));
        }

        [HttpPost("Desativar")]
        public async Task<IResult> Deactivate([FromBody] DesativarContaCommand command)
        {
            return Results.Ok(await _mediator.Send(command));
        }
    }
}
