namespace Medicines.Common
{
    public static class ValidationConstants
    {
        // Pharmacy
        public const int PharmacyNameMinLength = 2;
        public const int PharmacyNameMaxLength = 50;
        public const int PharmacyPhoneNumberLength = 14;
        public const string PharmacyPhoneNumberType = @"char(14)";
        public const string PharmacyPhoneNumberRegex = @"^\(\d{3}\) \d{3}-\d{4}$";
        public const string PharmacyBooleanRegex = @"^(true|false)$";

        // Medicine
        public const int MedicineNameMinLength = 3;
        public const int MedicineNameMaxLength = 150;
        public const string MedicinePriceType = @"decimal(18,2)";
        public const string MedicinePriceMinValue = "0.01";
        public const string MedicinePriceMaxValue = "1000.00";
        public const int MedicineProducerMinLength = 3;
        public const int MedicineProducerMaxLength = 100;
        public const int MedicineCategoryMinValue = 0;
        public const int MedicineCategoryMaxValue = 4;

        // Patient
        public const int PatientFullNameMinLength = 5;
        public const int PatientFullNameMaxLength = 100;
        public const int PatientAgeGroupMinValue = 0;
        public const int PatientAgeGroupMaxValue = 2;
        public const int PatientGenderMinValue = 0;
        public const int PatientGenderMaxValue = 1;
    }
}