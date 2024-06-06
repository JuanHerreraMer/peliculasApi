using AutoMapper;
using peliculasApi.DTOs;
using peliculasApi.Entidades;

namespace peliculasApi
{
    public class MappingConfig : Profile
    {

        public MappingConfig()
        {
            CreateMap<Genero, GeneroDTO>().ReverseMap();
            CreateMap<Genero, GeneroCreacionDTO>().ReverseMap();
        }
    }
}
