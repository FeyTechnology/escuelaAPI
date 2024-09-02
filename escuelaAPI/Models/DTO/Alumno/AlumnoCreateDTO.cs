using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace escuelaAPI.Models.DTO.Alumno
{
    public class AlumnoCreateDTO
    {
        
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Telefono { get; set; }
        public int GrupoId { get; set; }
    }
}
