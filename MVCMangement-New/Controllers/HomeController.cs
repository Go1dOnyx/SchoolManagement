﻿using Microsoft.AspNetCore.Mvc;
using MVCMangement_New.Models;
using System.Diagnostics;

namespace MVCMangement_New.Controllers
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

        [HttpPost]
        public IActionResult GoToSchool() 
        {
            return RedirectToAction("Index", "School");
        }

        [HttpPost]
        public IActionResult GoToStudent() 
        {
            return RedirectToAction("Index","Student");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}