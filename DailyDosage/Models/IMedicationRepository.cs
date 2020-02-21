using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyDosage.Models
{
    public interface IMedicationRepository
    {
        Medication GetMedication(int Id);
        IEnumerable<Medication> GetALLMedication();
        Medication Add(Medication medication);
        Medication Update(Medication medicationChanges);
        Medication Delete(int id);
    }
}
