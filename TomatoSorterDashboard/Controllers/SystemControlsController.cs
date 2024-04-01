using Microsoft.AspNetCore.Mvc;

namespace TomatoSorterDashboard.Controllers
{
    public class SystemControlsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
