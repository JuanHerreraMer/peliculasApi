using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using peliculasApi.Entidades;

namespace peliculasApi.Repositorios
{
    public interface IRepositorio
    {
        List<Genero> ObtenerTodosLosGeneros();

        Task<Genero> ObtenerGeneroById(int id);
    }
}