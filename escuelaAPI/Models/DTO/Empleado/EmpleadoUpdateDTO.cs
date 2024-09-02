using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace escuelaAPI.Models.DTO.Empleado
{
    public class EmpleadoUpdateDTO
    {
        public int Id { get; set; }
        
        public string Nombre { get; set; }
        
        public string ApellidoPaterno { get; set; }
        
        public string? ApellidoMaterno { get; set; }

        public int? GrupoId { get; set; }
     
        public int EscuelaId { get; set; }
        
        public int RoleId { get; set; }
        
    }
}
