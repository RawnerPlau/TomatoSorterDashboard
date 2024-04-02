using Microsoft.AspNetCore.Mvc;

namespace TomatoSorterDashboard.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
