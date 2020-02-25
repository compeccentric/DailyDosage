 using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
            

            var mondayMorns = from m in context.Medications
                              where m.MondayMorn == true &&
                              m.AccountId == userId
                              select m;
            var mondayAfters = from m in context.Medications
                               where m.MondayAfter == true &&
                              m.AccountId == userId
                               select m;
            var mondayEves = from m in context.Medications
                               where m.MondayEve == true &&
                              m.AccountId == userId
                             select m;
            ViewBag.MondayMorns = mondayMorns;
            ViewBag.MondayAfters = mondayAfters;
            ViewBag.MondayEves = mondayEves;

            var tuesdayMorns = from m in context.Medications
                              where m.TuesdayMorn == true &&
                              m.AccountId == userId
                               select m;
            var tuesdayAfters = from m in context.Medications
                               where m.TuesdayAfter == true &&
                              m.AccountId == userId
                                select m;
            var tuesdayEves = from m in context.Medications
                             where m.TuesdayEve == true &&
                              m.AccountId == userId
                              select m;
            ViewBag.TuesdayMorns = tuesdayMorns;
            ViewBag.TuesdayAfters = tuesdayAfters;
            ViewBag.TuesdayEves = tuesdayEves;
            

            var wednesdayMorns = from m in context.Medications
                               where m.WednesdayMorn == true &&
                              m.AccountId == userId
                                 select m;
            var wednesdayAfters = from m in context.Medications
                                where m.WednesdayAfter == true &&
                              m.AccountId == userId
                                  select m;
            var wednesdayEves = from m in context.Medications
                              where m.WednesdayEve == true &&
                              m.AccountId == userId
                                select m;
            ViewBag.WednesdayMorns = wednesdayMorns;
            ViewBag.WednesdayAfters = wednesdayAfters;
            ViewBag.WednesdayEves = wednesdayEves;

            var thursdayMorns = from m in context.Medications
                                 where m.ThursdayMorn == true &&
                              m.AccountId == userId
                                select m;
            var thursdayAfters = from m in context.Medications
                                  where m.ThursdayAfter == true &&
                              m.AccountId == userId
                                 select m;
            var thursdayEves = from m in context.Medications
                                where m.ThursdayEve == true &&
                              m.AccountId == userId
                               select m;
            ViewBag.ThursdayMorns = thursdayMorns;
            ViewBag.ThursdayAfters = thursdayAfters;
            ViewBag.ThursdayEves = thursdayEves;

            var fridayMorns = from m in context.Medications
                                where m.FridayMorn == true &&
                              m.AccountId == userId
                              select m;
            var fridayAfters = from m in context.Medications
                                 where m.FridayAfter == true &&
                              m.AccountId == userId
                               select m;
            var fridayEves = from m in context.Medications
                               where m.FridayEve == true &&
                              m.AccountId == userId
                             select m;
            ViewBag.FridayMorns = fridayMorns;
            ViewBag.FridayAfters = fridayAfters;
            ViewBag.FridayEves = fridayEves;

            var saturdayMorns = from m in context.Medications
                              where m.SaturdayMorn == true &&
                              m.AccountId == userId
                                select m;
            var saturdayAfters = from m in context.Medications
                               where m.SaturdayAfter == true &&
                              m.AccountId == userId
                                 select m;
            var saturdayEves = from m in context.Medications
                             where m.SaturdayEve == true &&
                              m.AccountId == userId
                               select m;
            ViewBag.SaturdayMorns = saturdayMorns;
            ViewBag.SaturdayAfters = saturdayAfters;
            ViewBag.SaturdayEves = saturdayEves;

            var sundayMorns = from m in context.Medications
                                where m.SundayMorn == true &&
                              m.AccountId == userId
                              select m;
            var sundayAfters = from m in context.Medications
                                 where m.SundayAfter == true &&
                              m.AccountId == userId
                               select m;
            var sundayEves = from m in context.Medications
                               where m.SundayEve == true &&
                              m.AccountId == userId
                             select m;
            ViewBag.SundayMorns = sundayMorns;
            ViewBag.SundayAfters = sundayAfters;
            ViewBag.SundayEves = sundayEves;

            return View();

        }
        
    }
}