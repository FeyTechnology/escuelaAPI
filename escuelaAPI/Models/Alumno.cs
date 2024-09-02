using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace escuelaAPI.Models
{
    public class Alumno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre {  get; set; }
        [Required]
        public string ApellidoPaterno {  get; set; }
        public string? ApellidoMaterno {  get; set; }
        public string? Telefono { get; set; }
        [ForeignKey("Estado")]
        public int EstadoId { get; set; } = 1;
        public Estado Estado { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        [ForeignKey("Grupo")]
        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }
    }
}
