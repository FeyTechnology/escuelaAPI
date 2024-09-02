using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace escuelaAPI.Models.DTO.Grupo
{
    public class GrupoCreateDTO
    {
        
        public string GrupoNombre { get; set; }
        public int EscuelaId { get; set; }
    }
}
