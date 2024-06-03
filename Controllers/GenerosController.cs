using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Genero> get()
        {
            return _repositorio.ObtenerTodosLosGeneros();
        }

        [HttpGet("{Id:int}/{nombre=Juan}")]
        public Genero get(int Id, string nombre)
        {
            var genero = _repositorio.ObtenerGeneroById(Id);

            if (genero == null)
            {
                return new Genero()
                {
                    Id = 10,
                    Nombre = "Jose"
                };
            }

            return genero;

        }

    }
}