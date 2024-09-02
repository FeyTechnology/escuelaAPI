using escuelaAPI.Data;
using escuelaAPI.Models;
using escuelaAPI.Repository.IRepository;
using FeytechAPI.Repository;

namespace escuelaAPI.Repository
{
    public class GrupoRepository : Repository<Grupo>, IGrupoRepository
    {
        private readonly ApplicationDbContext _db;
        public GrupoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
