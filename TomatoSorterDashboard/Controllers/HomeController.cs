using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Diagnostics;
using TomatoSorterDashboard.Interfaces;
using TomatoSorterDashboard.Models;

namespace TomatoSorterDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITomatoRepository _repository;

        public HomeController(ILogger<HomeController> logger, ITomatoRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        
        [Route("")]
        [Route("Home/Index")]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var tomatoes = await _repository.GetAllTomatoes();
            int ripe = tomatoes.Sum(x => x.RIPE);
            int halfripe = tomatoes.Sum(x => x.HALFRIPE);
            int unripe = tomatoes.Sum(x => x.UNRIPE);
            int defect = tomatoes.Sum(x => x.DEFECT);

            ViewBag.Ripe = ripe;
            ViewBag.HalfRipe = halfripe;
            ViewBag.Unripe = unripe;
            ViewBag.Defect = defect;
            ViewBag.Total = ripe+halfripe+unripe;

            HomeViewModel dashboardViewModel = new HomeViewModel()
            {
                Tomatoes = tomatoes
            };

            return View(dashboardViewModel);
        }

        [HttpGet]
        [Route("Home/GetDashboardValues")]
        public ActionResult GetDashboardValues()
        {
            var dashboardValues = _repository.GetDashboardValues();
            return Json(dashboardValues);
        }

        [Route("Home/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Home/Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
