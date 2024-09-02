using AutoMapper;
using escuelaAPI.Models;
using escuelaAPI.Models.DTO.Alumno;

namespace escuelaAPI.Configurations
{
    public class AlumnoMapperConfig : Profile
    {
        public AlumnoMapperConfig()
        {
            CreateMap<Alumno, AlumnoCreateDTO>().ReverseMap();
            CreateMap<Alumno, AlumnoUpdateDTO>().ReverseMap();
            CreateMap<Alumno, AlumnoDetailDTO>()
                .ForMember(d => d.EstadoNombre, m => m.MapFrom(s => s.Estado.EstadoNombre));
        }
    }
}
