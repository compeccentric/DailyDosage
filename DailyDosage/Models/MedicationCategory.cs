using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyDosage.Models
{
    public class MedicationCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public IList<Medication> Medications { get; set; }

    }
}
