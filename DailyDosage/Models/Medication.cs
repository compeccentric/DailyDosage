using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyDosage.Models
{
    public class Medication
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public int ID { get; set; }
        public string AccountId { get; set; }
        public int Dosage { get; set; }
        public MedicationCategory Category { get; set; }
        //public int CategoryID { get; set; }
        public string CategoryName { get; set; }
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

    }
}
