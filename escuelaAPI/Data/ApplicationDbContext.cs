using escuelaAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace escuelaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<Escuela> Escuela { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Estado> Estado { get; set; }

    }
}
