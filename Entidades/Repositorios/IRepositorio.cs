using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace peliculasApi.Entidades.Repositorios
{
    public interface IRepositorio
    {
        List<Genero> ObtenerTodosLosGeneros();

        Genero? ObtenerGeneroById(int id);
    }
}