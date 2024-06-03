using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using peliculasApi.Entidades;
using peliculasApi.Entidades.Repositorios;

namespace peliculasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenerosController : ControllerBase
    {
        private readonly IRepositorio _repositorio;

        public GenerosController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Genero>> get()
        {
            return _repositorio.ObtenerTodosLosGeneros();
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Genero>> get(int Id, [BindRequired] string nombre)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genero = await _repositorio.ObtenerGeneroById(Id);

            if (genero == null)
            {
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