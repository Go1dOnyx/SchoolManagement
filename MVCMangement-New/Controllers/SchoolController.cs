using Microsoft.AspNetCore.Mvc;
using Management.EF.Models;
using Management.EF.Context;
using Management.EF.Repositories;
using MVCMangement_New.Models;

namespace MVCMangement_New.Controllers
{
    public class SchoolController : Controller
    {
        private readonly SchoolManagementContext _context;

        public SchoolController(SchoolManagementContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            SchoolViewModel model = new SchoolViewModel(_context);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int districtID,string schoolName, string location, string administrator, string phoneNumber, int totalStudents)
        {
            SchoolViewModel model = new SchoolViewModel(_context);

            School district = new(districtID,schoolName, location, administrator, phoneNumber, totalStudents);

            model.SaveSchool(district);
            model.IsActionSuccess = true;
            model.ActionMessage = "School has been saved successfully";

            return View(model);
        }

        public IActionResult Update(int id)
        {
            SchoolViewModel model = new SchoolViewModel(_context, id);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            SchoolViewModel model = new SchoolViewModel(_context);

            if (id > 0)
            {
                model.RemoveSchool(id);
            }

            model.IsActionSuccess = true;
            model.ActionMessage = "District has been deleted successfully";
            return View("Index", model);
        }
    }
}
