namespace SGC.Models
{
    public class ClienteVM
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Telefone { get; set; } = null!;

        public string? Mensagem { get; set; }
    }
}
