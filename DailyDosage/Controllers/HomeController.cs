using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DailyDosage.Models;
using DailyDosage.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace DailyDosage.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(IMedicationRepository medicationRepository)
        {
            _medicationRepository = medicationRepository;
        }
        //private readonly ILogger<HomeController> _logger;
        private IMedicationRepository _medicationRepository;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        [AllowAnonymous]
        public IActionResult Index()
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
    }
}
