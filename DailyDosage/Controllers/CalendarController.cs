 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DailyDosage.Data;
using DailyDosage.Models;
using DailyDosage.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DailyDosage.Controllers
{
    public class CalendarController : Controller
    {
        private ApplicationDbContext context;
        public CalendarController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            var mondayMorns = from m in context.Medications
                              where m.MondayMorn == true
                              select m;
            var mondayAfters = from m in context.Medications
                               where m.MondayAfter == true
                               select m;
            var mondayEves = from m in context.Medications
                               where m.MondayEve == true
                               select m;
            ViewBag.MondayMorns = mondayMorns;
            ViewBag.MondayAfters = mondayAfters;
            ViewBag.MondayEves = mondayEves;

            var tuesdayMorns = from m in context.Medications
                              where m.MondayMorn == true
                              select m;
            var tuesdayAfters = from m in context.Medications
                               where m.MondayAfter == true
                               select m;
            var tuesdayEves = from m in context.Medications
                             where m.MondayEve == true
                             select m;
            ViewBag.TuesdayMorns = tuesdayMorns;
            ViewBag.TuesdayAfters = tuesdayAfters;
            ViewBag.TuesdayEves = tuesdayEves;
            return View();


        }
        
    }
}