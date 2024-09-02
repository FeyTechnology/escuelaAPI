using escuelaAPI.Data;
using escuelaAPI.Models;
using escuelaAPI.Repository.IRepository;
using FeytechAPI.Repository;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace escuelaAPI.Repository
{
    public class AlumnoRepository : Repository<Alumno>, IAlumnoRepository
    {
        private readonly ApplicationDbContext _db;
        public AlumnoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<List<Alumno>> GetAlumnoDetails()
        {
            var query = await _db.Alumno.Include(estado => estado.Estado).ToListAsync();
            return query;
        }
        public async Task<Alumno> UpdateAsync(Alumno entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Alumno.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
