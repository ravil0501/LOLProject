using LOLProject.Model;
using LOLProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LOLProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Heroes()
        {
            var model = new SelectModel();
            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Items()
        {
            var model = new LolprojectContext();
            return View(model);
        }

        public IActionResult viewItem()
        {
            return View();
        }

        public IActionResult HeroesInformation(string heroName)
        {
            var model = new LolprojectContext();
            ViewBag.heroName = heroName;
            return View(model);
        }

        public IActionResult Test()
        {
            var model = new LolprojectContext();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}