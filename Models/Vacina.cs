namespace VacinaWeb.Models
{
    public class Vacina
    {
        public int Id { get; set; }
        public string Nome { get; set; }        
        public string Fabricante { get; set; }
        public int Lote { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataDeValidade { get; set; }

    }
}
