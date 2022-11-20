using MVCWebNTier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ISchoolRepository
    {
        Task<int> CreateSchool(School school);
        int EditSchool(int id);
        Task<IEnumerable<School>> GetAllSchools();
        Task<School> GetSchoolById(string id);

        Task<int> AddSchool(School school);
        Task<int> UpdateSchool(School school);
        Task<School> FindSchoolById(string id);
        bool DeleteSchool(School school);
    }
}
