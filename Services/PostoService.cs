using Microsoft.Extensions.Hosting;
using VacinaWeb.Models;
using VacinaWeb.Models.Requests;
using VacinaWeb.Repository.Interfaces;
using VacinaWeb.Services.Interfaces;

namespace VacinaWeb.Services
{
    public class PostoService : IPostoService
    {
        private readonly IPostoRepository _postoRepository;
        public PostoService(IPostoRepository postoRepository)
        {
            _postoRepository = postoRepository;
        }
        public async Task AlterarPosto(AlterarPostoRequest posto)
        {
            await _postoRepository.AlterarPosto(posto);  
        }

        public async Task DeletarPosto(int id)
        {
            await _postoRepository.DeletarPosto(id);
        }

        public async Task<Posto> GetPostoById(int id)
        {
            return await _postoRepository.GetPostoById(id);
        }

        public async Task<IEnumerable<Posto>> GetPostos()
        {
            return await _postoRepository.GetPostos();
        }

        public async Task<IEnumerable<Posto>> GetPostosByName(string nome)
        {
            return await _postoRepository.GetPostosByName(nome);
        }

        public async Task IncluirPosto(IncluirPostoRequest posto)
        {
            await _postoRepository.IncluirPosto(posto);
        }
    }
}
