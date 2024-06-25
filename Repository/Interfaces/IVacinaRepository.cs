using System.Collections.Generic;
using System.Threading.Tasks;
using VacinaWeb.Models;
using VacinaWeb.Models.Requests;

namespace VacinaWeb.Repository.Interfaces
{
    public interface IVacinaRepository
    {
        Task<IEnumerable<Vacina>> GetVacinas();
        Task<IEnumerable<Vacina>> GetVacinasByName(string nome);
        Task<Vacina> GetVacinaById(int id);
        Task IncluirVacina(IncluirVacinaRequest vacina);
        Task AlterarVacina(AlterarVacinaRequest vacina);
        Task DeletarVacina(int id);
    }
}
