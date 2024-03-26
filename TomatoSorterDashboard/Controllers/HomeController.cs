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
            Tomato tomato = await _repository.GetOneTomatoDoc();
            ViewBag.Total = tomato.Total;
            ViewBag.Ripe = tomato.Ripe;
            ViewBag.HalfRipe = tomato.HalfRipe;
            ViewBag.Unripe = tomato.Unripe;
            ViewBag.Defect = tomato.Defect;
            return View(tomato);
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
