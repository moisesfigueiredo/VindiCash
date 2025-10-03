using MediatR;
using Vindi.Cash.Api.Application.Dtos;

namespace Vindi.Cash.Api.Application.Members.Queries
{
    public class ObterContaPorIdQuery : IRequest<ServiceResult>
    {
        public int? Id { get; set; }
    }
}
