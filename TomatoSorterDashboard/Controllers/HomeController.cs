using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            var tomatoes = await _repository.GetAllTomatoes();
            int ripe = tomatoes.Sum(x => x.Ripe);
            int halfripe = tomatoes.Sum(x => x.HalfRipe);
            int unripe = tomatoes.Sum(x => x.Unripe);
            int defect = tomatoes.Sum(x => x.Defect);

            ViewBag.Ripe = ripe;
            ViewBag.HalfRipe = halfripe;   
            ViewBag.Unripe = unripe;
            ViewBag.Defect = defect;
            ViewBag.Total = ripe+halfripe+unripe+defect;

            DashboardViewModel dashboardViewModel = new DashboardViewModel()
            {
                Tomatoes = tomatoes
            };

            return View(dashboardViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
