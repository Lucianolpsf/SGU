namespace SGU.Models
{
    public class ManutencaoVM
    {
        public int Id { get; set; }

        public string Tecnica { get; set; } = null!;

        public decimal Valor { get; set; }

        public int Prazo { get; set; }

        public int FkServico { get; set; }
    }
}
