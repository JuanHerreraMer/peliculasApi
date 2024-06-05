using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using peliculasApi.Entidades;

namespace peliculasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenerosController : ControllerBase
    {
        private readonly ILogger<GenerosController> _logger;

        public GenerosController(ILogger<GenerosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Genero>> Get()
        {
            return new List<Genero>() { new Genero() { Id = 1, Nombre = "Comedia" } };
        }

        [HttpGet("{Id:int}")]
        public ActionResult<Genero> Get(int Id)
        {
            throw new NotImplementedException();
        }


        [HttpPost]
        public ActionResult Post([FromBody] Genero genero)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genero genero)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            throw new NotImplementedException();
        }

    }
}