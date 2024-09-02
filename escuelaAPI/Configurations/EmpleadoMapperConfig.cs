using AutoMapper;
using escuelaAPI.Models;
using escuelaAPI.Models.DTO.Empleado;

namespace escuelaAPI.Configurations
{
    public class EmpleadoMapperConfig : Profile
    {
        public EmpleadoMapperConfig()
        {
            CreateMap<Empleado, EmpleadoCreateDTO>().ReverseMap();
            CreateMap<Empleado, EmpleadoUpdateDTO>().ReverseMap();
        }
    }
}
