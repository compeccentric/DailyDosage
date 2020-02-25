using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DailyDosage.Models;
using Microsoft.AspNetCore.Http;

namespace DailyDosage.ViewModels
{
    public class DetailsMedicationViewModel : AddMedicationViewModel
    {
        public Medication Medication { get; set; }
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }





    }
}
