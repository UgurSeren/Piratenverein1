using Microsoft.AspNetCore.Mvc;
using Piratenverein1.Models;
using System.Diagnostics;

namespace Piratenverein1.Controllers
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
            return View();
        }
        public IActionResult Index1()
        {
            
            return View();
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NormalPirat pirat)
        {
            string ergebnis;
            if (ModelState.IsValid)
            {
                if (pirat.Alt < 10)
                {
                    ergebnis = "KinderPirats";

                    return RedirectToAction("CreateNew", ergebnis, pirat);
                }
                else
                {
                    ergebnis = "NormalPirats";

                    return RedirectToAction("CreateNew", ergebnis, pirat);
                }
            }
            return RedirectToAction("Create", pirat);
        }
    }
}