using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DailyDosage.Data;

namespace DailyDosage.Models
{
    public class SQLMedicationRepository : IMedicationRepository
    {
        private readonly ApplicationDbContext context;
        public SQLMedicationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Medication Add(Medication medication)
        {
            context.Medications.Add(medication);
            context.SaveChanges();
            return medication;
        }

        public Medication Delete(int id)
        {
            Medication medication = context.Medications.Find(id);
            if (medication != null)
            {
                context.Medications.Remove(medication);
                context.SaveChanges();
            }
            return medication;
        }

        public IEnumerable<Medication> GetALLMedication()
        {
            return context.Medications;
        }

        public Medication GetMedication(int Id)
        {
            return context.Medications.Find(Id);
        }

       
        public Medication Update(Medication medicationChanges)
        {
            var medication = context.Medications.Attach(medicationChanges);
            medication.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return medicationChanges;
        }
    }
}
