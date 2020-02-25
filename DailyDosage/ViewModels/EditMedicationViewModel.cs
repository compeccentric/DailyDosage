using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DailyDosage.Models;

namespace DailyDosage.ViewModels
{
    public class EditMedicationViewModel : AddMedicationViewModel
    {
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }

    }
}
