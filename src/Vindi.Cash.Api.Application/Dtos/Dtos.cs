namespace Vindi.Cash.Api.Application.Dtos
{
    public record CreateAccountDto(string Name, string Document);
    public record AccountDto(int Id, string Name, string Document, decimal Balance, DateTime OpeningDate, bool IsActive);
    public record TransferDto(string FromDocument, string ToDocument, decimal Amount, string PerformedBy);
    public record DeactivateDto(string Document, string PerformedBy);
}
