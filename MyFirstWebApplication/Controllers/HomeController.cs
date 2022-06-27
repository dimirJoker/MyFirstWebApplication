using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstWebApplication.Models;
using MyFirstWebApplication.Services;
using System.Diagnostics;

namespace MyFirstWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ItemsTable itemsTable = new();

            return View(itemsTable.GetAllItems());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Insert(ItemModel item)
        {
            return RedirectToAction("Index");
        }

        public IActionResult Details(uint id)
        {
            ItemsTable itemsTable = new();

            return View(itemsTable.GetItemById(id));
        }

        public IActionResult Edit(uint id)
        {
            ItemsTable itemsTable = new();

            return View(itemsTable.GetItemById(id));
        }

        public IActionResult Update(ItemModel item)
        {
            ItemsTable itemsTable = new();
            itemsTable.Update(item);

            return View("Details", itemsTable.GetItemById(item.Id));
        }

        public IActionResult Delete(uint id)
        {
            ItemsTable itemsTable = new();
            itemsTable.Delete(id);

            return RedirectToAction("Index");
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