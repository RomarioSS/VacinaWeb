using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VacinaWeb.Models;
using VacinaWeb.Models.Requests;
using VacinaWeb.Repository.Interfaces;
using VacinaWeb.Services.Interfaces;

namespace VacinaWeb.Services
{
    public class VacinaService : IVacinaService
    {
        private readonly IVacinaRepository _vacinaRepository;

        public VacinaService(IVacinaRepository vacinaRepository)
        {
            _vacinaRepository = vacinaRepository;
        }

        public async Task AlterarVacina(AlterarVacinaRequest vacina)
        {
            ValidateDataDeValidade(vacina.DataDeValidade);

            await _vacinaRepository.AlterarVacina(vacina);
        }

        public async Task DeletarVacina(int id)
        {
            await _vacinaRepository.DeletarVacina(id);
        }

        public async Task<Vacina> GetVacinaById(int id)
        {
            return await _vacinaRepository.GetVacinaById(id);
        }

        public async Task<IEnumerable<Vacina>> GetVacinas()
        {
            return await _vacinaRepository.GetVacinas();
        }

        public async Task<IEnumerable<Vacina>> GetVacinasByName(string nome)
        {
            return await _vacinaRepository.GetVacinasByName(nome);
        }

        public async Task IncluirVacina(IncluirVacinaRequest vacina)
        {
            ValidateDataDeValidade(vacina.DataDeValidade);

            await _vacinaRepository.IncluirVacina(vacina);
        }

        private void ValidateDataDeValidade(DateTime dataDeValidade)
        {
            if (dataDeValidade.Date <= DateTime.Today)
            {
                throw new ArgumentException("A data de validade deve ser uma data futura (não pode ser hoje).");
            }
        }
    }
}
