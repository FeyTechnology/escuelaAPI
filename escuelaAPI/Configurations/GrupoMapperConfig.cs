using AutoMapper;
using escuelaAPI.Models;
using escuelaAPI.Models.DTO.Grupo;

namespace escuelaAPI.Configurations
{
    public class GrupoMapperConfig : Profile
    {
        public GrupoMapperConfig()
        {
            CreateMap<Grupo, GrupoCreateDTO>().ReverseMap();
        }
    }
}
