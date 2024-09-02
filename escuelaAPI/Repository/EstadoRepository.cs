using escuelaAPI.Data;
using escuelaAPI.Models;
using escuelaAPI.Repository.IRepository;
using FeytechAPI.Repository;

namespace escuelaAPI.Repository
{
    public class EstadoRepository : Repository<Estado>, IEstadoRepository
    {
        private readonly ApplicationDbContext _db;
        public EstadoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
