namespace Vindi.Cash.Api.Domain.Entities
{
    public class Transacao : EntityBase
    {
        public int ContaOrigemId { get; set; }
        public int ContaDestinoId { get; set; }
        public decimal Quantia { get; set; }
        public DateTime CriadaEm { get; set; }
    }
}
