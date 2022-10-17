using Microsoft.AspNetCore.Mvc;

namespace TrainingSystem.Controllers
{
    public class KhoaHocController : Controller
    {
        public IActionResult Index()
        {
            return View("xemkhoahoc");
        }
    }
}
