using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DailyDosage.Data;
using DailyDosage.Models;
using DailyDosage.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DailyDosage.Controllers
{

    public class MedicationController : Controller
    {
       
        private IMedicationRepository _medicationRepository;

        private readonly ApplicationDbContext context;
        private readonly IHostingEnvironment hostingEnvironment;

        private readonly UserManager<ApplicationUser> userManager;
        public MedicationController(ApplicationDbContext dbContext, IHostingEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager, IMedicationRepository medicationRepository)
        {
            context = dbContext;
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
            _medicationRepository = medicationRepository;
        }


        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
            var userName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

            ApplicationUser applicationUser = await userManager.GetUserAsync(User);
            string userEmail = applicationUser?.Email; // will give the user's Email
            var AccountMeds = from m in context.Medications
                              where m.AccountId == userId
                              select m;
            ViewBag.AccountMeds = AccountMeds;
            
            return View();
        }
        public ViewResult Edit(int id)
        {
            Medication medication = _medicationRepository.GetMedication(id);
            EditMedicationViewModel editMedicationViewModel = new EditMedicationViewModel
            {
                Id = medication.ID,
                Name = medication.Name,

            };
            return View(editMedicationViewModel);
        }
        public ViewResult Details(int id)
        {
            Medication medication = _medicationRepository.GetMedication(id);
            DetailsMedicationViewModel detailsMedicationViewModel = new DetailsMedicationViewModel
            {
                Medication = medication,
                Id = medication.ID,
                Name = medication.Name,
               
              

            };
            return View(detailsMedicationViewModel);
        }
        public IActionResult Add()
        {
            AddMedicationViewModel addMedicationViewModel = new AddMedicationViewModel(context.Categories.ToList());
            return View(addMedicationViewModel);
        }
        [HttpPost]
        public IActionResult Add(AddMedicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                MedicationCategory newMedicationCategory = context.Categories.Single(c => c.ID == model.Category);
                Medication newMedication = new Medication
                {
                    Name = model.Name,
                    Description = model.Description,
                    PhotoPath = uniqueFileName,
                    Category = newMedicationCategory,
                    AccountId = model.AccountId,

                    //Dosage = addMedicationViewModel.Dosage,
                    //MondayMorn = addMedicationViewModel.MondayMorn,
                    //MondayAfter = addMedicationViewModel.MondayAfter,
                    //MondayEve = addMedicationViewModel.MondayEve,
                    //TuesdayMorn = addMedicationViewModel.TuesdayMorn,
                    //TuesdayAfter = addMedicationViewModel.TuesdayAfter,
                    //TuesdayEve = addMedicationViewModel.TuesdayEve,
                    //WednesdayMorn = addMedicationViewModel.WednesdayMorn,
                    //WednesdayAfter = addMedicationViewModel.WednesdayAfter,
                    //WednesdayEve = addMedicationViewModel.WednesdayEve,
                    //ThursdayMorn = addMedicationViewModel.ThursdayMorn,
                    //ThursdayAfter = addMedicationViewModel.ThursdayAfter,
                    //ThursdayEve = addMedicationViewModel.ThursdayEve,
                    //FridayMorn = addMedicationViewModel.FridayMorn,
                    //FridayAfter = addMedicationViewModel.FridayAfter,
                    //FridayEve = addMedicationViewModel.FridayEve,
                    //SaturdayMorn = addMedicationViewModel.SaturdayMorn,
                    //SaturdayAfter = addMedicationViewModel.SaturdayAfter,
                    //SaturdayEve = addMedicationViewModel.SaturdayEve,
                    //SundayMorn = addMedicationViewModel.SundayMorn,
                    //SundayAfter = addMedicationViewModel.SundayAfter,
                    //SundayEve = addMedicationViewModel.SundayEve,

                };
                context.Medications.Add(newMedication);
                context.SaveChanges();

                return RedirectToAction("Index","Medication");
            }
            return View(model);
            
        }

        public IActionResult Remove() 
        {
            IList<Medication> medications = context.Medications.ToList();
            return View(medications);
        }

        [HttpPost]
        public IActionResult Remove(int[] medicationIds)
        {
            foreach (int medicationId in medicationIds)
            {
                Medication theMedication = context.Medications.Single(c => c.ID == medicationId);
                context.Medications.Remove(theMedication);
            }
            context.SaveChanges();
            return Redirect("/Medication");
        }

       
    }
}