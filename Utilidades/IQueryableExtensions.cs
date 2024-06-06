using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using peliculasApi.DTOs;

namespace peliculasApi.Utilidades
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, PaginacionDTO paginacionDTO)
        {
            return queryable
            .Skip((paginacionDTO.Pagina - 1) * paginacionDTO.RecordsPorPagina)
            .Take(paginacionDTO.RecordsPorPagina);
        }
    }
}