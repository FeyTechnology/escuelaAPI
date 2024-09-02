using escuelaAPI.Data;
using escuelaAPI.Models;
using escuelaAPI.Repository.IRepository;
using FeytechAPI.Repository;

namespace escuelaAPI.Repository
{
    public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
    {
        private readonly ApplicationDbContext _db;
        public EmpleadoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
