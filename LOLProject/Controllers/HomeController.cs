using LOLProject.Model;
using LOLProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebSockets;

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
            var model = new AddItemModel();
            return View(model);
        }

        public async Task<byte[]> ConvertIFormFileToByteArrayAsync(IFormFile file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public async Task<IActionResult> Upload(IFormFile file)
        {
            byte[] fileBytes = await ConvertIFormFileToByteArrayAsync(file);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public  IActionResult viewItem(AddItemModel model)
        {
            model.Error = "";
            model.ErrorCount = 0;
            var dbContext = new LolprojectContext();
            string extension = Path.GetExtension(model.image.FileName);
            if(extension != ".png" && extension != ".jpg" && extension != ".jpeg"){
                model.Error = "Файл не представляет собой изображение";
                return View(model);
            }

            using var fileStream = model.image.OpenReadStream();
            byte[] bytes = new byte[model.image.Length];
            var p = fileStream.Read(bytes, 0, (int)model.image.Length);

            model.ImageItem = bytes;

            if (string.IsNullOrWhiteSpace(model.ItemName))
            {
                model.Error = "Пустое имя";
                return View(model);
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(model.Hp)))
            {
                model.ErrorCount++;
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(model.Ap)))
            {
                model.ErrorCount++;
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(model.Armor)))
            {
                model.ErrorCount++;
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(model.IdDiff)))
            {
                model.Error = "Пустая категория";
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(model.Ad)))
            {
                model.ErrorCount++;
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(model.AttackSpeed)))
            {
                model.ErrorCount++;
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(model.Crit)))
            {
                model.ErrorCount++;
            }

            bool nulable = string.IsNullOrWhiteSpace(model.Error);
            if (nulable && model.ErrorCount<6)
            {
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
            }
            else
            {
                model.Error = "Вы не ввели ни одного свойства предмета";
            }
            return View(model);
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

        public IActionResult ChooseHero()
        {
            var hero = new ChoosenHero();
            return View(hero);
        }

        [HttpPost]
        public IActionResult ChooseHero(ChoosenHero hero)
        {
            return View(hero);
        }
        
        public IActionResult Hero(ChoosenHero hero, int _c)
        {
            return View(hero);
        }

        [HttpPost]
        public IActionResult ChooseItems(ChoosenHero hero) 
        { 
            return View(hero);
        }

        public IActionResult ChooseItems(ChoosenHero hero, int _i)
        {
            return View(hero);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}