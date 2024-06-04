using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using peliculasApi.Entidades;
using peliculasApi.Repositorios;

namespace peliculasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenerosController : ControllerBase
    {
        private readonly IRepositorio _repositorio;
        private readonly ILogger<GenerosController> _logger;

        public GenerosController(IRepositorio repositorio, ILogger<GenerosController> logger)
        {
            _repositorio = repositorio;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Genero>> get()
        {
            _logger.LogInformation("Vamos a mostrar los generos");
            return _repositorio.ObtenerTodosLosGeneros();
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Genero>> get(int Id, [BindRequired] string nombre)
        {

            _logger.LogDebug("Obteniendo un género por el ID");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genero = await _repositorio.ObtenerGeneroById(Id);

            if (genero == null)
            {
                _logger.LogWarning($"No pudimos encontrar el género de id {Id}");
                return NotFound();
            }

            return genero;

        }


        [HttpPost]
        public ActionResult Post([FromBody] Genero genero)
        {
            return NoContent();
        }

    }
}