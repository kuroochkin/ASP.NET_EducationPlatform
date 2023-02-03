using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_EducationPlatform.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
