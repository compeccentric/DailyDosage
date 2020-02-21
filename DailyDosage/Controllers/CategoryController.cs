using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DailyDosage.Data;
using DailyDosage.Models;
using DailyDosage.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DailyDosage.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            List<MedicationCategory> allCategories = context.Categories.ToList();
            return View(allCategories);
        }
        private readonly ApplicationDbContext context;
        public CategoryController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }
        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                MedicationCategory newCategory = new MedicationCategory
                {
                    Name = addCategoryViewModel.Name
                };
                context.Categories.Add(newCategory);
                context.SaveChanges();
                return Redirect("/Category");
            }
            return View(addCategoryViewModel);
        }
        public IActionResult Remove()
        {
            List<MedicationCategory> allCategories = context.Categories.ToList();
            return View(allCategories);
        }

        [HttpPost]
        public IActionResult Remove(int[] categoryIds)
        {
            foreach (int categoryId in categoryIds)
            {
                MedicationCategory theCategory = context.Categories.Single(c => c.ID == categoryId);
                context.Categories.Remove(theCategory);
            }
            context.SaveChanges();
            return Redirect("/Category");
        }
    }
}