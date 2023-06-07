using LOLProject.Model;
using LOLProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
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

        [HttpGet]
        public IActionResult Heroes()
        {
            var model = new SelectModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Heroes(SelectModel model)
        {
            if(model.selectedValue != 0)
            {
                model.selectedValue = 7;
            }
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

        [HttpGet]
        public IActionResult viewItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult viewItem(AddItemModel model)
        {
            var dbContext = new LolprojectContext();
            dbContext.Add(new Item
            {
                ItemName = model.ItemName,
                ImageItem = model.ImageItem,
                Ad = model.Ad,
                AttackSpeed = model.AttackSpeed,
                Ap = model.AttackSpeed,
                Movement = model.Movement,
                Armor = model.Armor,
                Hp = model.Hp,
                Modificators = model.Modificators
                
            });
            dbContext.SaveChanges();
            var c = (from a in dbContext.Items
                     where a.ItemName == model.ItemName
                     select a).Single();
            dbContext.Add(new ItemsDifference
            {
                IdItem = c.Id,
                IdDiff = model.IdDiff
            });
            dbContext.SaveChanges();
            return View();
        }
        public int? IdDiff { get; set; }

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