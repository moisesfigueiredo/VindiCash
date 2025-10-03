using MediatR;
using Vindi.Cash.Api.Application.Dtos;
using Vindi.Cash.Api.Domain.Abstractions;
using Vindi.Cash.Api.Domain.Entities;

namespace Vindi.Cash.Api.Application.Members.Commands
{
    public class CriarTransferenciaCommandHandler : IRequestHandler<CriarTransferenciaCommand, ServiceResult>
    {
        private readonly ITransacaoRepository _transferRepository;
        private readonly IContaRepository _accountsRepository;

        public CriarTransferenciaCommandHandler(ITransacaoRepository transferRepository, IContaRepository accountsRepository)
        {
            _transferRepository = transferRepository;
            _accountsRepository = accountsRepository;
        }

        public async Task<ServiceResult> Handle(CriarTransferenciaCommand request, CancellationToken cancellationToken)
        {
            ServiceResult result = new();

            try
            {
                if (request.Quantia <= 0)
                {
                    result.AddError("Valor deve ser maior do que zero");
                    return result;
                }

                var from = await _accountsRepository.GetFirst(a => a.Documento == request.DocumentoOrigem);
                var to = await _accountsRepository.GetFirst(a => a.Documento == request.DocumentoDestino);

                if (from == null || to == null)
                {
                    result.AddError("Uma ou mais contas não encontradas.");
                    return result;
                }

                if (!from.Ativa || !to.Ativa)
                {
                    result.AddError("As duas contas devem estar ativa.");
                    return result;
                }

                if (from.Saldo < request.Quantia)
                {
                    result.AddError("Saldo insuficiente na conta de origem");
                    return result;
                }

                from.Saldo -= request.Quantia.Value;
                to.Saldo += request.Quantia.Value;

                await _accountsRepository.Update(from);
                await _accountsRepository.Update(to);

                var tx = new Transacao
                {
                    ContaOrigemId = from.Id,
                    ContaDestinoId = to.Id,
                    Quantia = request.Quantia.Value,
                    CriadaEm = DateTime.UtcNow
                };

                await _transferRepository.Insert(tx);

            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }

            return result;
        }
    }
}
