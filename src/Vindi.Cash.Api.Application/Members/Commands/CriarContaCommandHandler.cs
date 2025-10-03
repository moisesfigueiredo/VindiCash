using MediatR;
using Microsoft.AspNetCore.Http;
using Vindi.Cash.Api.Application.Dtos;
using Vindi.Cash.Api.Domain.Abstractions;
using Vindi.Cash.Api.Domain.Entities;
using Vindi.Cash.Api.Domain.Validation;

namespace Vindi.Cash.Api.Application.Members.Commands
{
    public class CriarContaCommandHandler : IRequestHandler<CriarContaCommand, ServiceResult>
    {
        private readonly IContaRepository _accountsRepository;
        private const decimal InitialBonus = 1000m;

        public CriarContaCommandHandler(IContaRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        public async Task<ServiceResult> Handle(CriarContaCommand request, CancellationToken cancellationToken)
        {
            ServiceResult result = new();

            try
            {
                if (string.IsNullOrWhiteSpace(request.Nome) || string.IsNullOrWhiteSpace(request.Documento))
                    result.AddError("Nome e documento são obrigatórios.");

                var exists = await _accountsRepository.GetFirst(a => a.Documento == request.Documento);

                if (exists != null)
                    result.AddError("Já existe uma conta com esse documento.");

                var acc = new Conta
                {
                    Nome = request.Nome.Trim(),
                    Documento = request.Documento.Trim(),
                    Saldo = InitialBonus,
                    DataAbertura = DateTime.UtcNow,
                    Ativa = true
                };

                await _accountsRepository.Insert(acc);
            }
            catch (DomainValidation ex)
            {
                var errosDetail = new ErrorResultDetail(ErrorResultDetail.INVALID_INPUT.Code, ex.Message) { StatusCode = StatusCodes.Status400BadRequest };
                result.AddError(errosDetail);

            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }

            return result;
        }
    }
}
