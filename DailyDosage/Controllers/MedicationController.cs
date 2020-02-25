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
        
        public ViewResult Details(int id)
        {
            Medication medication = _medicationRepository.GetMedication(id);
            DetailsMedicationViewModel detailsMedicationViewModel = new DetailsMedicationViewModel
            {
                Medication = medication,
                Id = medication.ID,
                Name = medication.Name,
                Dosage = medication.Dosage,
                CategoryName = medication.CategoryName,
                Description = medication.Description,
                



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
                string uniqueFileName = ProcessUploadedFile(model);

                //MedicationCategory newMedicationCategory = context.Categories.Single(c => c.ID == model.Category);
                Medication newMedication = new Medication
                {
                    Name = model.Name,
                    Description = model.Description,
                    PhotoPath = uniqueFileName,
                    CategoryName = model.CategoryName,
                    AccountId = model.AccountId,

                    Dosage = model.Dosage,
                    MondayMorn = model.MondayMorn,
                    MondayAfter = model.MondayAfter,
                    MondayEve = model.MondayEve,
                    TuesdayMorn = model.TuesdayMorn,
                    TuesdayAfter = model.TuesdayAfter,
                    TuesdayEve = model.TuesdayEve,
                    WednesdayMorn = model.WednesdayMorn,
                    WednesdayAfter = model.WednesdayAfter,
                    WednesdayEve = model.WednesdayEve,
                    ThursdayMorn = model.ThursdayMorn,
                    ThursdayAfter = model.ThursdayAfter,
                    ThursdayEve = model.ThursdayEve,
                    FridayMorn = model.FridayMorn,
                    FridayAfter = model.FridayAfter,
                    FridayEve = model.FridayEve,
                    SaturdayMorn = model.SaturdayMorn,
                    SaturdayAfter = model.SaturdayAfter,
                    SaturdayEve = model.SaturdayEve,
                    SundayMorn = model.SundayMorn,
                    SundayAfter = model.SundayAfter,
                    SundayEve = model.SundayEve

                };
                context.Medications.Add(newMedication);
                context.SaveChanges();

                return RedirectToAction("Index","Medication");
            }
            return View(model);
            
        }

        //public IActionResult Remove() 
        //{
        //    IList<Medication> medications = context.Medications.ToList();
        //    return View(medications);
        //}

        //[HttpPost]
        //public IActionResult Remove(int[] medicationIds)
        //{
        //    foreach (int medicationId in medicationIds)
        //    {
        //        Medication theMedication = context.Medications.Single(c => c.ID == medicationId);
        //        context.Medications.Remove(theMedication);
        //    }
        //    context.SaveChanges();
        //    return Redirect("/Medication");
        //}
        //[HttpPost]
        public async Task<IActionResult>  Delete(int id)
        {
            var medication = await context.Medications.FindAsync(id);
            context.Medications.Remove(medication);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");

            //Medication theMedication = context.Medications.Single(c => c.ID == medicationId);
            //    context.Medications.Remove(theMedication);

            //context.SaveChanges();
            //return Redirect("Medication");
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            //Medication medication = _medicationRepository.GetMedication(id);
            //EditMedicationViewModel editMedicationViewModel = new EditMedicationViewModel

            Medication medication = context.Medications.Find(id);
            EditMedicationViewModel editMedicationViewModel = new EditMedicationViewModel
            {
                Id = medication.ID,
                Name = medication.Name,
                Description = medication.Description,
                Dosage = medication.Dosage,
                CategoryName = medication.CategoryName,
                ExistingPhotoPath = medication.PhotoPath
            };
            return View(editMedicationViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditMedicationViewModel model)
        {
            if (ModelState.IsValid)
            {

                //Medication medication = _medicationRepository.GetMedication(model.Id);
                
                Medication medication = context.Medications.Find(model.Id);
                medication.Name = model.Name;
                medication.Description = model.Description;
                medication.CategoryName = model.CategoryName;
                
                medication.Dosage = model.Dosage;
                medication.MondayMorn = model.MondayMorn;
                medication.MondayAfter = model.MondayAfter;
                medication.MondayEve = model.MondayEve;
                medication.TuesdayMorn = model.TuesdayMorn;
                medication.TuesdayAfter = model.TuesdayAfter;
                medication.TuesdayEve = model.TuesdayEve;
                medication.WednesdayMorn = model.WednesdayMorn;
                medication.WednesdayAfter = model.WednesdayAfter;
                medication.WednesdayEve = model.WednesdayEve;
                medication.ThursdayMorn = model.ThursdayMorn;
                medication.ThursdayAfter = model.ThursdayAfter;
                medication.ThursdayEve = model.ThursdayEve;
                medication.FridayMorn = model.FridayMorn;
                medication.FridayAfter = model.FridayAfter;
                medication.FridayEve = model.FridayEve;
                medication.SaturdayMorn = model.SaturdayMorn;
                medication.SaturdayAfter = model.SaturdayAfter;
                medication.SaturdayEve = model.SaturdayEve;
                medication.SundayMorn = model.SundayMorn;
                medication.SundayAfter = model.SundayAfter;
                medication.SundayEve = model.SundayEve;

                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    medication.PhotoPath = ProcessUploadedFile(model);
                }


                context.Medications.Update(medication);
                context.SaveChanges();
                return RedirectToAction("index");

                
            }
            return View(model);
        }
        private string ProcessUploadedFile(AddMedicationViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

    }

}