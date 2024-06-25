using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using VacinaWeb.Models;
using VacinaWeb.Models.Requests;
using VacinaWeb.Services;
using VacinaWeb.Services.Interfaces;


namespace VacinaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PostoController : ControllerBase
    {
        public readonly IPostoService _postoService;
        public PostoController(IPostoService postoService)
        {
            _postoService = postoService;
        }
        
        [HttpGet("~/api/Postos/")]
        
        public async Task<IActionResult> ListarPostos()
        {
            try
            {
                return Ok(await _postoService.GetPostos());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("~/api/Postos/id/{id}")]
        public async Task<IActionResult> BuscarPostoPorId(int id)
        {
            try
            {
                return Ok(await _postoService.GetPostoById(id));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("~/api/Postos/nome/{nome}")]
        public async Task<IActionResult> BuscarPostoPorNome(string nome)
        {
            try
            {
                return Ok(await _postoService.GetPostosByName(nome));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("~/api/Postos/")]
        public async Task<IActionResult> IncluirPosto([FromQuery] IncluirPostoRequest posto)
        {
            try
            {
                await _postoService.IncluirPosto(posto);
                return Ok(new { Succes = true });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpDelete("~/api/Postos/")]
        public async Task<IActionResult> DeletarPosto([FromQuery] int id)
        {
            {
                try
                {
                    await _postoService.DeletarPosto(id);
                    return Ok(new { Succes = true });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
        }
        [HttpPut("~/api/Postos/")]
        public async Task<IActionResult> AlterarPosto([FromQuery] AlterarPostoRequest posto)
        {
            try
            {
                await _postoService.AlterarPosto(posto);
                return Ok(new { Succes = true });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
