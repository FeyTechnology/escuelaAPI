using AutoMapper;
using escuelaAPI.Models;
using escuelaAPI.Models.DTO.Estado;

namespace escuelaAPI.Configurations
{
    public class EstadoMapperConfig : Profile
    {
        public EstadoMapperConfig() 
        {
            CreateMap<Estado, EstadoCreateDTO>().ReverseMap();
        }
    }
}
