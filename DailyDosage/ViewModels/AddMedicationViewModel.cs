using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DailyDosage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DailyDosage.ViewModels
{
    public class AddMedicationViewModel
    {
        [Required]
        [Display(Name= "Medication Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You must give your medication a description")]
        public string AccountId { get; set; }
        public string Description { get; set; }
        public IFormFile Photo { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int Category { get; set; }
        public int Dosage { get; set; }
        public bool MondayMorn { get; set; }
        public bool MondayAfter { get; set; }
        public bool MondayEve { get; set; }
        public bool TuesdayMorn { get; set; }
        public bool TuesdayAfter { get; set; }
        public bool TuesdayEve { get; set; }
        public bool WednesdayMorn { get; set; }
        public bool WednesdayAfter { get; set; }
        public bool WednesdayEve { get; set; }
        public bool ThursdayMorn { get; set; }
        public bool ThursdayAfter { get; set; }
        public bool ThursdayEve { get; set; }
        public bool FridayMorn { get; set; }
        public bool FridayAfter { get; set; }
        public bool FridayEve { get; set; }
        public bool SaturdayMorn { get; set; }
        public bool SaturdayAfter { get; set; }
        public bool SaturdayEve { get; set; }
        public bool SundayMorn { get; set; }
        public bool SundayAfter { get; set; }
        public bool SundayEve { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public AddMedicationViewModel(IEnumerable<MedicationCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.ID.ToString(),
                    Text = category.Name
                });

            }
            this.Categories = Categories;
        }
        public AddMedicationViewModel() { }
    }
}
