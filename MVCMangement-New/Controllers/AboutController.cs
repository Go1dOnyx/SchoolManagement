using Microsoft.AspNetCore.Mvc;

namespace MVCMangement_New.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
