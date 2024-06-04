using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using peliculasApi.Entidades;

namespace peliculasApi.Repositorios
{
    public class RepositorioEnMemoria : IRepositorio
    {

        private List<Genero> _generos;

        public RepositorioEnMemoria()
        {
            _generos = new List<Genero>{
                new Genero(){Id=1, Nombre="Comedia"},
                new Genero(){Id=2, Nombre="Acción"}
            };
        }

        public List<Genero> ObtenerTodosLosGeneros()
        {
            return _generos;
        }

        public async Task<Genero> ObtenerGeneroById(int id){

            await Task.Delay(TimeSpan.FromSeconds(2));

            return _generos.FirstOrDefault(x => x.Id == id);
        }
    }
}