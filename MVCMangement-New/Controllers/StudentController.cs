using Microsoft.AspNetCore.Mvc;
using Management.EF.Models;
using Management.EF.Context;
using Management.EF.Repositories;
using MVCMangement_New.Models;


namespace MVCMangement_New.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolManagementContext _context;

        public StudentController(SchoolManagementContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            StudentViewModel model = new StudentViewModel(_context);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int studentID, int distrcitID, string firstN, string lastN, DateTime birth, string addre, string grade)
        {
                StudentViewModel model = new StudentViewModel(_context);

                Student student = new(studentID, distrcitID, firstN, lastN, birth, addre, grade);

                model.SaveStudent(student);
                model.IsActionSuccess = true;
                model.ActionMessage = "Student has been saved successfully";

                return View(model);
        }

        public IActionResult Update(int id)
        {
            StudentViewModel model = new StudentViewModel(_context, id);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            StudentViewModel model = new StudentViewModel(_context);

            if (id > 0)
            {
                model.RemoveStudent(id);
            }

            model.IsActionSuccess = true;
            model.ActionMessage = "Student has been deleted successfully";
            return View("Index", model);
        }
    }
}
