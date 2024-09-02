using AutoMapper;
using escuelaAPI.Models;
using escuelaAPI.Models.DTO.Role;

namespace escuelaAPI.Configurations
{
    public class RoleMapperConfig : Profile
    {
        public RoleMapperConfig() 
        {
            CreateMap<Role, RoleCreateDTO>().ReverseMap();
        }
    }
}
