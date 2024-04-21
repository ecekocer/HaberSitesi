using Microsoft.AspNetCore.Mvc;

namespace HaberSitesi.Controllers
{
    public class EditorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
