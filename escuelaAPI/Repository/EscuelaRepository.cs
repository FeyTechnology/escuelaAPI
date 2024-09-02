using escuelaAPI.Data;
using escuelaAPI.Models;
using escuelaAPI.Repository.IRepository;
using FeytechAPI.Repository;

namespace escuelaAPI.Repository
{
    public class EscuelaRepository : Repository<Escuela>, IEscuelaRepository
    {
        private readonly ApplicationDbContext _db;
        public EscuelaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
