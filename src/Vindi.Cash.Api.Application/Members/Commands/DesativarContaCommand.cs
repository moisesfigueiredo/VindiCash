using MediatR;
using Vindi.Cash.Api.Application.Dtos;

namespace Vindi.Cash.Api.Application.Members.Commands
{
    public class DesativarContaCommand : IRequest<ServiceResult>
    {
        public string Documento { get; set; }
    }
}
