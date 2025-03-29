using Medicines.Data;
using Medicines.Data.Models.Enums;
using Medicines.DataProcessor.ExportDtos;
using Medicines.Utilities;
using Newtonsoft.Json;

namespace Medicines.DataProcessor
{
    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            string result = string.Empty;

            if (!DateTime.TryParse(date, out DateTime givenDate))
            {
                throw new ArgumentException("Invalid date format!");
            }

            var patients = context.Patients
                .Where(p => p.PatientsMedicines.Any(pm => pm.Medicine.ProductionDate >= givenDate))
                .Select(p => new ExportPatientDto
                {
                    Name = p.FullName,
                    AgeGroup = p.AgeGroup.ToString(),
                    Gender = p.Gender.ToString().ToLower(),
                    Medicines = p.PatientsMedicines
                        .Where(pm => pm.Medicine.ProductionDate >= givenDate)
                        .Select(pm => pm.Medicine)
                        .OrderByDescending(m => m.ExpiryDate)
                        .ThenBy(m => m.Price)
                        .Select(m => new ExportMedicineDto
                        {
                            Name = m.Name,
                            Price = m.Price.ToString("F2"),
                            Category = m.Category.ToString().ToLower(),
                            Producer = m.Producer,
                            BestBefore = m.ExpiryDate.ToString("yyyy-MM-dd")

                        })
                        .ToArray()

                })
                .OrderByDescending(p => p.Medicines.Length)
                .ThenBy(p => p.Name)
                .ToArray();

            result = XmlHelper.Serialize(patients, "Patients");
            return result;
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            string result = string.Empty;

            var medicines = context.Medicines
                .Where(m => m.Category == (Category)medicineCategory && m.Pharmacy.IsNonStop)
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .Select(m => new
                {
                    Name = m.Name,
                    Price = m.Price.ToString("F2"),
                    Pharmacy = new
                    {
                        Name = m.Pharmacy.Name,
                        PhoneNumber = m.Pharmacy.PhoneNumber
                    }
                })
                .ToArray();

            result = JsonConvert.SerializeObject(medicines, Formatting.Indented);
            return result;
        }
    }
}
