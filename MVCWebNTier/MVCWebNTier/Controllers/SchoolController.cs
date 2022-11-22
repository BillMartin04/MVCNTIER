using Microsoft.AspNetCore.Mvc;
using MVCWebNTier.Models;
using MVCWebNTier.ViewModel.NewFolder;
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


        public IActionResult Index()
        {
            var listOfSchools = _schoolService.GetAllSchools();
            return View(ConvertToSchoolViewModel(listOfSchools));
        }

        private IEnumerable<SchoolViewModel> ConvertToSchoolViewModel(Task<IEnumerable<School>> listOfSchools)
        {
            var schools = new List<SchoolViewModel>();
   
            foreach (var school in listOfSchools.Result)
            {        
                var schoolViewModel = new SchoolViewModel();
                schoolViewModel.SchoolName = school.SchoolName;
                schoolViewModel.SchoolID = school.SchoolID;
                schools.Add(schoolViewModel);
            }
            return schools;
        }

        // GET: Schools/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Schools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schools/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
    }
}
