using escuelaAPI.Models;
using FeytechAPI.Repository.IRepository;

namespace escuelaAPI.Repository.IRepository
{
    public interface IAlumnoRepository : IRepository<Alumno>
    {
        Task<List<Alumno>> GetAlumnoDetails();
        Task<Alumno> UpdateAsync(Alumno entity);
    }
}
