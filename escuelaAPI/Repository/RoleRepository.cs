using escuelaAPI.Data;
using escuelaAPI.Models;
using escuelaAPI.Repository.IRepository;
using FeytechAPI.Repository;

namespace escuelaAPI.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly ApplicationDbContext _db;
        public RoleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
