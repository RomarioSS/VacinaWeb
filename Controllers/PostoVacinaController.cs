using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Threading.Tasks;
using VacinaWeb.Models;
using VacinaWeb.Models.Requests;
using VacinaWeb.Services;
using VacinaWeb.Services.Interfaces;

namespace VacinaWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostoVacinaController : ControllerBase
    {
        private readonly IPostoVacinaService _postoVacinaService;

        public PostoVacinaController(IPostoVacinaService postoVacinaService)
        {
            _postoVacinaService = postoVacinaService;
        }

        [HttpGet("{idPosto}/{idVacina}")]
        public async Task<IActionResult> GetPostoVacina(int idPosto, int idVacina)
        {
            try
            {
                var result = await _postoVacinaService.GetPostoVacinaByPostoAndVacina(idPosto, idVacina);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> IncluirPostoVacina([FromBody] IncluirPostoVacinaRequest request)
        {
            try
            {
                var postoVacina = new PostoVacina
                {
                    IdPosto = request.IdPosto,
                    IdVacina = request.IdVacina,
                    Quantidade = request.Quantidade
                };

                await _postoVacinaService.IncluirPostoVacina(postoVacina);
                return Ok(new { Success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> AlterarPostoVacina([FromBody] AlterarPostoVacinaRequest request)
        {
            try
            {

                var postoVacina = new PostoVacina
                {
                    Id = request.Id,
                    IdPosto = request.IdPosto,
                    IdVacina = request.IdVacina,
                    Quantidade = request.Quantidade
                };

                await _postoVacinaService.AlterarPostoVacina(postoVacina);
                return Ok(new { Success = true });
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPostoVacina(int id)
        {
            try
            {
                await _postoVacinaService.DeletarPostoVacina(id);
                return Ok(new { Success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("posto/{idPosto}")]
        public async Task<IActionResult> GetPostoVacinaByPosto(int idPosto)
        {
            try
            {
                var result = await _postoVacinaService.GetPostoVacinaByPosto(idPosto);
                return Ok(result);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("vacina/{idVacina}")]
        public async Task<IActionResult> GetPostoByVacina(int idVacina)
        {
            try
            {
                var result = await _postoVacinaService.GetPostoByVacina(idVacina);
                return Ok(result);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
