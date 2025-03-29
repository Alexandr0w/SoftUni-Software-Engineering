using Medicines.Data;
using Medicines.Data.Models;
using Medicines.Data.Models.Enums;
using Medicines.DataProcessor.ImportDtos;
using Medicines.Utilities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace Medicines.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportPatientDto[]? patientDtos = JsonConvert.DeserializeObject<ImportPatientDto[]>(jsonString);

            if (patientDtos != null && patientDtos.Length > 0)
            {
                ICollection<Patient> dbPatients = new List<Patient>();

                foreach (ImportPatientDto patientDto in patientDtos)
                {
                    if (!IsValid(patientDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Patient patient = new Patient
                    {
                        FullName = patientDto.FullName,
                        AgeGroup = (AgeGroup)patientDto.AgeGroup,
                        Gender = (Gender)patientDto.Gender
                    };

                    foreach (int medId in patientDto.Medicines)
                    {
                        if (patient.PatientsMedicines.Any(pm => pm.MedicineId == medId))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        PatientMedicine patientMedicine = new PatientMedicine
                        {
                            Patient = patient,
                            MedicineId = medId
                        };

                        patient.PatientsMedicines.Add(patientMedicine);
                    }

                    dbPatients.Add(patient);
                    sb.AppendLine(string.Format(SuccessfullyImportedPatient, patient.FullName, patient.PatientsMedicines.Count));
                }

                context.Patients.AddRange(dbPatients);
                context.SaveChanges();
            }

            return sb.ToString().Trim();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            ImportPharmacyDto[]? pharmacyDtos = XmlHelper.Deserialize<ImportPharmacyDto[]>(xmlString, "Pharmacies");

            if (pharmacyDtos != null && pharmacyDtos.Length > 0)
            {
                ICollection<Pharmacy> dbPharmacies = new List<Pharmacy>();
                
                foreach (ImportPharmacyDto pharmacyDto in pharmacyDtos)
                {
                    bool isValidIsNonStop = bool.TryParse(pharmacyDto.IsNonStop, out bool isNonStop);

                    if (!IsValid(pharmacyDto) || !isValidIsNonStop)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Pharmacy pharmacy = new Pharmacy
                    {
                        IsNonStop = isNonStop,
                        Name = pharmacyDto.Name,
                        PhoneNumber = pharmacyDto.PhoneNumber
                    };

                    foreach (var medicineDto in pharmacyDto.Medicines)
                    {
                        bool isProductionDateValid = DateTime
                            .TryParseExact(medicineDto.ProductionDate, "yyyy-MM-dd", CultureInfo
                            .InvariantCulture, DateTimeStyles.None, out DateTime medicineProductionDate);

                        bool isExpityDateValid = DateTime
                            .TryParseExact(medicineDto.ExpiryDate, "yyyy-MM-dd", CultureInfo
                            .InvariantCulture, DateTimeStyles.None, out DateTime medicineExpityDate);

                        if (!IsValid(medicineDto) || !isProductionDateValid || !isExpityDateValid)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (medicineProductionDate >= medicineExpityDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (pharmacy.Medicines.Any(m => m.Name == medicineDto.Name && m.Producer == medicineDto.Producer))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        Medicine medicine = new Medicine
                        {
                            Name = medicineDto.Name,
                            Price = medicineDto.Price,
                            Category = (Category)medicineDto.Category,
                            ProductionDate = medicineProductionDate,
                            ExpiryDate = medicineExpityDate,
                            Producer = medicineDto.Producer
                        };

                        pharmacy.Medicines.Add(medicine);
                    }

                    dbPharmacies.Add(pharmacy);
                    sb.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
                }

                context.Pharmacies.AddRange(dbPharmacies);
                context.SaveChanges();
            }

            return sb.ToString().Trim();

        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
