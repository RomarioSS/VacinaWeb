using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VacinaWeb.Models;
using VacinaWeb.Models.Requests;
using VacinaWeb.Repository.Interfaces;
using VacinaWeb.Services;
using VacinaWeb.Services.Interfaces;

namespace VacinaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class VacinaController : ControllerBase
    {
        private readonly IVacinaService _vacinaService;

        public VacinaController(IVacinaService vacinaService)
        {
            _vacinaService = vacinaService;
        }

        [HttpGet("~/api/Vacinas/")]
        public async Task<IActionResult> Vacinas()
        {
            try
            {
                var vacinas = await _vacinaService.GetVacinas();
                return Ok(vacinas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
 
        }

        [HttpGet("~/api/Vacinas/{id}")]
        public async Task<IActionResult> Vacina(int id)
        {
            try
            {
                var vacina = await _vacinaService.GetVacinaById(id);
                if (vacina == null)
                {
                    return NotFound();
                }
                return Ok(vacina);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
         
        }

        [HttpGet("~/api/Vacinas/nome/{nome}")]
        public async Task<IActionResult> VacinasPorNome(string nome)
        {
            try
            {
                var vacinas = await _vacinaService.GetVacinasByName(nome);
                return Ok(vacinas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("~/api/Vacinas/")]
        public async Task<IActionResult> IncluirVacina([FromBody] IncluirVacinaRequest vacina)
        {
            try
            {
                await _vacinaService.IncluirVacina(vacina);
                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }

        [HttpDelete("~/api/Vacinas/{id}")]
        public async Task<IActionResult> DeletarVacina(int id)
        {
            try
            {
                await _vacinaService.DeletarVacina(id);
                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }

        }

        [HttpPut("~/api/Vacinas/")]
        public async Task<IActionResult> AlterarVacina([FromBody] AlterarVacinaRequest vacina)
        {
            try
            {
                await _vacinaService.AlterarVacina(vacina);
                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }
    }
}
