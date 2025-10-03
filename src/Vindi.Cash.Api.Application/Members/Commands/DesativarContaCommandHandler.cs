using MediatR;
using Vindi.Cash.Api.Application.Dtos;
using Vindi.Cash.Api.Domain.Abstractions;
using Vindi.Cash.Api.Domain.Entities;

namespace Vindi.Cash.Api.Application.Members.Commands
{
    public class DesativarContaCommandHandler : IRequestHandler<DesativarContaCommand, ServiceResult>
    {
        private readonly IContaRepository _accountsRepository;
        private readonly ILogDesativacaoRepository _deactivationLogRepository;

        public DesativarContaCommandHandler(IContaRepository accountsRepository, ILogDesativacaoRepository deactivationLogRepository)
        {
            _accountsRepository = accountsRepository;
            _deactivationLogRepository = deactivationLogRepository;
        }

        public async Task<ServiceResult> Handle(DesativarContaCommand request, CancellationToken cancellationToken)
        {
            ServiceResult result = new();

            try
            {
                if (string.IsNullOrWhiteSpace(request.Documento))
                    result.AddError("Documento requerido.");

                var acc = await _accountsRepository.GetFirst(a => a.Documento == request.Documento);

                if (acc == null)
                {
                    result.AddError("Conta não encontrada.");
                    return result;
                }

                if (!acc.Ativa)
                {
                    result.AddError("Conta já se encontra inativa.");
                    return result;
                }

                acc.Ativa = false;

                await _accountsRepository.Update(acc);

                await _deactivationLogRepository.Insert(new LogDesativacao { Documento = request.Documento, DataDesativacao = DateTime.UtcNow });
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }

            return result;
        }
    }
}
