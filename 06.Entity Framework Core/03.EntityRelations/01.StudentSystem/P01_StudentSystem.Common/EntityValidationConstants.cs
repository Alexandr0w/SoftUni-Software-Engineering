namespace P01_StudentSystem.Common
{
    public static class EntityValidationConstants
    {
        public static class Student
        {
            public const int StudentNameMaxLength = 100;
            public const int PhoneNumberMaxLength = 10;
        }
        public static class Course
        {
            public const int CourseNameMaxLength = 80;
        }
        public static class Resource
        {
            public const int ResourceNameMaxLength = 50;
            public const int UrlMaxLength = 2048;
        }
    }
}
