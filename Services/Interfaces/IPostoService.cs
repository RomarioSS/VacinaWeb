using Microsoft.AspNetCore.Mvc;
using VacinaWeb.Models;
using VacinaWeb.Models.Requests;

namespace VacinaWeb.Services.Interfaces
{
    public interface IPostoService
    {
        public Task<IEnumerable<Posto>> GetPostos();
        public Task<IEnumerable<Posto>> GetPostosByName(string nome);
        public Task<Posto> GetPostoById(int id);
        public Task IncluirPosto(IncluirPostoRequest posto);
        public Task AlterarPosto(AlterarPostoRequest posto);
        public Task DeletarPosto(int id);

    }
}
