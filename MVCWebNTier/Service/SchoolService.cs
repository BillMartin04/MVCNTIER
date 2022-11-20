using MVCWebNTier.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SchoolService : ISchoolService
    {
        ISchoolRepository _schoolRepository;

        public SchoolService(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public async Task<List<School>> AddSchool(School school)
        {
            return await _schoolRepository.AddSchool(school);
        }

        public Task<int> CreateSchool(School School)
        {
            return _schoolRepository.CreateSchool(School);
        }

        public bool DeleteSchool(School School)
        {
            return _schoolRepository.DeleteSchool(School);
        }

        public async Task<School> FindSchoolById(string id)
        {
            return await _schoolRepository.FindSchoolById(id);
        }

        public async Task<IEnumerable<School>> GetAllSchools()
        {
            return await _schoolRepository.GetAllSchools();
        }

        public School GetSchool(string id)
        {
            var newSchool = new School()
            {
                SchoolName = "Nicole",
                SchoolID = "Kidman"
            };

            return newSchool;
        }

        public async Task<School> GetSchoolByID(string id)
        {
            return await _schoolRepository.GetSchoolById(id);
        }

        public async Task<int> UpdateSchool(School school)
        {
            return await _schoolRepository.UpdateSchool(school);
        }

        public async Task<int> AddSchool(School school)
        {
            return await _schoolRepository.AddSchool(school);
        }
    }
}
