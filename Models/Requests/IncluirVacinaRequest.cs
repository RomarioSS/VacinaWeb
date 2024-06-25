namespace VacinaWeb.Models.Requests
{
    public class IncluirVacinaRequest
    {
        public string Nome { get; set; }
        public string Fabricante { get; set; }
        public int Lote { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataDeValidade { get; set; }
    }
}
