using System.Collections.Generic;
using System.Threading.Tasks;
using VacinaWeb.Models;

namespace VacinaWeb.Services.Interfaces
{
    public interface IPostoVacinaService
    {
        Task<PostoVacina> GetPostoVacinaByPostoAndVacina(int idPosto, int IdVacina);
        Task<IEnumerable<PostoVacina>> GetPostoVacinaByPosto(int idPosto);
        Task<IEnumerable<PostoVacina>> GetPostoByVacina(int IdVacina);
        Task IncluirPostoVacina(PostoVacina PostoVacina);
        Task AlterarPostoVacina(PostoVacina PostoVacina);
        Task DeletarPostoVacina(int id);
    }
}
