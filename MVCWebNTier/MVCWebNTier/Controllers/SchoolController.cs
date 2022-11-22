using Microsoft.AspNetCore.Mvc;
using MVCWebNTier.Models;
using MVCWebNTier.ViewModel.School;
using Service;

namespace MVCWebNTier.Controllers
{
    public class SchoolController : Controller
    {
        private readonly ISchoolService _schoolService;


        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }
        // GET: Schools


        public async Task<ActionResult> Index()
        {
            var listOfSchools = await _schoolService.GetAllSchools();
            return View(ConvertToSchoolViewModel(listOfSchools));
        }

        // GET: Schools/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var school =  await _schoolService.GetSchoolByID(id.ToString());
            return View(ConvertToSchoolDetailsViewModel(school));
        }

        private SchoolViewModel ConvertToSchoolDetailsViewModel(School school)
        {
            return new SchoolViewModel()
            {
                SchoolID = school.SchoolID,
                SchoolName = school.SchoolName
            };
        }

        // GET: Schools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schools/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(School school)
        {
            await _schoolService.CreateSchool(school);
            return View("Index", ConvertToSchoolViewModel( await _schoolService.GetAllSchools()));
        }

        // GET: Schools/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Schools/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Schools/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Schools/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        private IEnumerable<SchoolViewModel> ConvertToSchoolViewModel(IEnumerable<School> listOfSchools)
        {
            var schools = new List<SchoolViewModel>();

            foreach (var school in listOfSchools)
            {
                var schoolViewModel = new SchoolViewModel();
                schoolViewModel.SchoolName = school.SchoolName;
                schoolViewModel.SchoolID = school.SchoolID;
                schools.Add(schoolViewModel);
            }
            return schools;
        }
    }
}
