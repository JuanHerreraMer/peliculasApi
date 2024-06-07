using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using peliculasApi.DTOs;
using peliculasApi.Entidades;
using peliculasApi.Utilidades;

namespace peliculasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly ILogger<GenerosController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GenerosController(ILogger<GenerosController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GeneroDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = _context.Generos.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);
            var generos = await queryable.OrderBy(x => x.Nombre).Paginar(paginacionDTO).ToListAsync();
            return _mapper.Map<List<GeneroDTO>>(generos);

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GeneroDTO>> Get(int id)
        {
            var genero = await _context.Generos.FirstOrDefaultAsync(x => x.Id == id);

            if (genero == null) return NotFound();

            return _mapper.Map<GeneroDTO>(genero);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = _mapper.Map<Genero>(generoCreacionDTO);
            _context.Add(genero);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = await _context.Generos.FirstOrDefaultAsync(x => x.Id == id);

            if (genero == null) return NotFound();

            genero = _mapper.Map(generoCreacionDTO, genero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Generos.AnyAsync(x => x.Id == id);
            if (!existe) return NotFound();

            _context.Remove(new Genero() { Id = id });
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}