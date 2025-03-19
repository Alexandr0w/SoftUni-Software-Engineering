namespace TravelAgency.Common
{
    public static class ValidationConstants
    {
        public const int CustomerNameMinLength = 4;
        public const int CustomerNameMaxLength = 60;

        public const int CustomerEmailMinLength = 6;
        public const int CustomerEmailMaxLength = 50;

        public const int PhoneNumberMaxLength = 13;
        public const string PhoneNumberPattern = @"^\+\d{12}$";

        public const int GuideNameMinLength = 4;
        public const int GuideNameMaxLength = 60;

        public const int PackageNameMinLength = 2;
        public const int PackageNameMaxLength = 40;

        public const int DescriptionMaxLength = 200;
    }
}
