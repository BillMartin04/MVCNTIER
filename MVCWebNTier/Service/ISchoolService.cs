using MVCWebNTier.Models;
using System;

namespace Service
{
    public interface ISchoolService
    {
        Task<IEnumerable<School>> GetAllSchools();
        Task<int> AddSchool(School school);

        Task<School> GetSchoolByID(string id);

        Task<int> CreateSchool(School school);
        Task<int> UpdateSchool(School school);
        Task<School> FindSchoolById(string id);
        bool DeleteSchool(School school);
    }
}