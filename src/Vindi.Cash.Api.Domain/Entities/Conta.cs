using System.ComponentModel.DataAnnotations;

namespace Vindi.Cash.Api.Domain.Entities
{
    public class Conta : EntityBase
    {
        [Required]
        public string Nome { get; set; } = null!;

        [Required]
        public string Documento { get; set; } = null!;

        public decimal Saldo { get; set; }

        public DateTime DataAbertura { get; set; }

        public bool Ativa { get; set; } = true;

        public List<Transacao> Transacoes { get; set; } = new();
    }
}
