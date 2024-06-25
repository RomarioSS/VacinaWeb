namespace VacinaWeb.Models.Requests
{
    public class IncluirPostoVacinaRequest
    {
        public int IdPosto { get; set; }
        public int IdVacina { get; set; }
        public int Quantidade { get; set; }
    }
}
