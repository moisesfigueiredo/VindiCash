using MediatR;
using Vindi.Cash.Api.Application.Dtos;

namespace Vindi.Cash.Api.Application.Members.Commands
{
    public class CriarTransferenciaCommand : IRequest<ServiceResult>
    {
        public string? DocumentoOrigem {get; set;}
        public string? DocumentoDestino {get; set;}
        public decimal? Quantia {get; set;}
        public string? ExecutadaPor {get; set;}
    }
}

