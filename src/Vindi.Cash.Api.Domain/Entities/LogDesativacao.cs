namespace Vindi.Cash.Api.Domain.Entities
{
    public class LogDesativacao : EntityBase
    {
        public string Documento { get; set; } = null!;
        public DateTime DataDesativacao { get; set; }
        public string ExecutadaPor { get; set; } = "system"; 
    }
}
