using MediatR;
using Vindi.Cash.Api.Application.Dtos;

namespace Vindi.Cash.Api.Application.Members.Queries
{
    public class ObterTodasContasQuery : IRequest<ServiceResult>
    {
        public string? Nome { get; set; }
        public string? Documento { get; set; }
    }
}
