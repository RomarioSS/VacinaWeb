using System.Collections.Generic;
using System.Threading.Tasks;
using VacinaWeb.Models;
using VacinaWeb.Repository.Interfaces;
using VacinaWeb.Services.Interfaces;

namespace VacinaWeb.Services
{
    public class PostoVacinaService : IPostoVacinaService
    {
        private readonly IPostoVacinaRepository _postoVacinaRepository;

        public PostoVacinaService(IPostoVacinaRepository postoVacinaRepository)
        {
            _postoVacinaRepository = postoVacinaRepository;
        }

        public async Task AlterarPostoVacina(PostoVacina postoVacina)
        {
            await _postoVacinaRepository.UpdatePostoVacinaAsync(postoVacina);
        }

        public async Task DeletarPostoVacina(int id)
        {
            await _postoVacinaRepository.DeletePostoVacinaAsync(id);
        }

        public async Task<IEnumerable<PostoVacina>> GetPostoByVacina(int idVacina)
        {
            return await _postoVacinaRepository.GetPostoByVacinaAsync(idVacina);
        }

        public async Task<IEnumerable<PostoVacina>> GetPostoVacinaByPosto(int idPosto)
        {
            return await _postoVacinaRepository.GetPostoVacinaByPostoAsync(idPosto);
        }

        public async Task<PostoVacina> GetPostoVacinaByPostoAndVacina(int idPosto, int idVacina)
        {
            return await _postoVacinaRepository.GetPostoVacinaByPostoAndVacinaAsync(idPosto, idVacina);
        }

        public async Task IncluirPostoVacina(PostoVacina postoVacina)
        {
            await _postoVacinaRepository.AddPostoVacinaAsync(postoVacina);
        }
    }
}
