namespace P01_HospitalDatabase.Common
{
    public static class ValidationConstants
    {
        public static class Patient
        {
            public const int PatientFirstNameMaxLength = 50;
            public const int PatientLastNameMaxLength = 50;
            public const int PatientAddressMaxLength = 250;
            public const int PatientEmailMaxLength = 80;
        }

        public static class Visitation
        {
            public const int VisitationCommentsMaxLength = 250;
        }

        public static class Diagnose
        {
            public const int DiagnoseNameMaxLength = 50;
            public const int DiagnoseCommentsMaxLength = 250;
        }

        public static class Medicament
        {
            public const int MedicamentNameMaxLength = 50;
        }

        public static class Doctor
        {
            public const int DoctorNameMaxLength = 100;
            public const int DoctorSpecialtyMaxLength = 100;
            public const int DoctorEmailMaxLength = 80;
            public const int DoctorPasswordMaxLength = 100;
        }
    }
}
