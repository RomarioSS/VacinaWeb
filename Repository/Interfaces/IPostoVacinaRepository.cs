using System.Collections.Generic;
using System.Threading.Tasks;
using VacinaWeb.Models;

namespace VacinaWeb.Repository.Interfaces
{
    public interface IPostoVacinaRepository
    {
        Task<IEnumerable<PostoVacina>> GetAllPostosAsync();
        Task<PostoVacina> GetPostoByIdAsync(int id);
        Task AddPostoVacinaAsync(PostoVacina postoVacina);
        Task UpdatePostoVacinaAsync(PostoVacina postoVacina);
        Task DeletePostoVacinaAsync(int id);
        Task<IEnumerable<PostoVacina>> GetPostoByVacinaAsync(int idVacina);
        Task<IEnumerable<PostoVacina>> GetPostoVacinaByPostoAsync(int idPosto);
        Task<PostoVacina> GetPostoVacinaByPostoAndVacinaAsync(int idPosto, int idVacina);
        Task<bool> HasVacinasAsync(int postoId);
        Task<bool> IsDuplicatePostoNameAsync(string nome);
    }
}
