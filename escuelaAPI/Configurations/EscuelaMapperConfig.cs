using AutoMapper;
using escuelaAPI.Models;
using escuelaAPI.Models.DTO.Escuela;

namespace escuelaAPI.Configurations
{
    public class EscuelaMapperConfig : Profile
    {
        public EscuelaMapperConfig()
        {
            CreateMap<Escuela, EscuelaCreateDTO>().ReverseMap();
        }
    }
}
