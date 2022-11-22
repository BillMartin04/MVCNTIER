using Microsoft.EntityFrameworkCore;
using MVCWebNTier.Data.Context;
using MVCWebNTier.Models;

namespace Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SchoolContext _context;
        public SchoolRepository(SchoolContext context) 
        {
            _context = context;
        }

        public async Task<int> AddSchool(School school) 
        {
            _context.Add(school);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CreateSchool(School school)
        {
            _context.Add(school);
            return await _context.SaveChangesAsync();
        }

        public bool DeleteSchool(School school)
        {
            _context.Schools.Remove(school);
            return true;
        }

        public int EditSchool(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<School> FindSchoolById(string id)
        {
            return await _context.Schools.FindAsync(id);
        }

        public async Task<IEnumerable<School>> GetAllSchools()
        {
            return await _context.Schools.ToListAsync();
        }

        public async Task<School> GetSchoolById(string id)
        {
            return await _context.Schools
           .FirstOrDefaultAsync(m => m.SchoolID == id);
        }

        public async Task<int> UpdateSchool(School School)
        {
            _context.Update(School);
            return await _context.SaveChangesAsync();
        }
    }
}
