using MediatR;
using Vindi.Cash.Api.Application.Dtos;
using Vindi.Cash.Api.Domain.Abstractions;

namespace Vindi.Cash.Api.Application.Members.Queries
{
    public class ObterContaPorIdQueryHandler : IRequestHandler<ObterContaPorIdQuery, ServiceResult>
    {
        private readonly IContaRepository _accountsRepository;

        public ObterContaPorIdQueryHandler(IContaRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        public async Task<ServiceResult> Handle(ObterContaPorIdQuery request, CancellationToken cancellationToken)
        {
            ServiceResult<AccountDto> result = new();

            try
            {
                var a = await _accountsRepository.GetFirst(request.Id);

                if (a == null) result.AddError("Não encontrado.");

                var dto = new AccountDto(a.Id, a.Nome, a.Documento, a.Saldo, a.DataAbertura, a.Ativa);

                result.Data = dto;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }

            return result;
        }
    }
}
