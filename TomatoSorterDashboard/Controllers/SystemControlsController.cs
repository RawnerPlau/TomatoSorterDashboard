using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TomatoSorterDashboard.Interfaces;
using TomatoSorterDashboard.Models;

namespace TomatoSorterDashboard.Controllers
{
    [Route("[controller]/[action]")]
    public class SystemControlsController : Controller
    {
        private readonly IControlsRepository _controlsRepository;

        public SystemControlsController(IControlsRepository controlsRepository)
        {
            _controlsRepository = controlsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateToggles([FromBody] Toggle data)
        {
            Dictionary<string, object> newdata = new Dictionary<string, object>{
                { data.Key, data.Value }
            };
            _controlsRepository.ToggleSwitch(data);
            
            return Ok();
        }
    }
}
