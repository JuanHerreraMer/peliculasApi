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

            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<Actor, ActorCreacionDTO>().ReverseMap()
                .ForMember(x => x.Foto, options => options.Ignore());
        }
    }
}
