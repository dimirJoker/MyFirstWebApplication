using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstWebApplication.Models;
using MyFirstWebApplication.Services;
using System;
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
            ItemsList itemsList = new();

            return View(itemsList.GetAllItems());
        }

        public IActionResult Details(uint id)
        {
            ItemsList itemsList = new();

            return View(itemsList.GetItemById(id));
        }

        public IActionResult Edit(uint id)
        {
            ItemsList itemsList = new();

            return View(itemsList.GetItemById(id));
        }

        public IActionResult Update(ItemModel item)
        {
            ItemsList itemsList = new();
            itemsList.Update(item);

            return View("Details", itemsList.GetItemById(item.Id));
        }

        public IActionResult Delete(uint id)
        {
            ItemsList itemsList = new();
			itemsList.Delete(id);

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