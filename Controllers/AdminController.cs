using Microsoft.AspNetCore.Mvc;

namespace HaberSitesi.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
