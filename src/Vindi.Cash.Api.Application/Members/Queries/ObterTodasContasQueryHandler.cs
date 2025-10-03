using MediatR;
using Vindi.Cash.Api.Application.Dtos;
using Vindi.Cash.Api.Domain.Abstractions;
using Vindi.Cash.Api.Domain.Entities;

namespace Vindi.Cash.Api.Application.Members.Queries
{
    public class ObterTodasContasQueryHandler : IRequestHandler<ObterTodasContasQuery, ServiceResult>
    {
        private readonly IContaRepository _accountsRepository;

        public ObterTodasContasQueryHandler(IContaRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        public async Task<ServiceResult> Handle(ObterTodasContasQuery request, CancellationToken cancellationToken)
        {
            ServiceResult<List<Conta>> result = new();

            try
            {
                var list = await _accountsRepository.GetAllAsync(request.Nome, request.Documento);

                result.Data = list;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }

            return result;
        }
    }
}
