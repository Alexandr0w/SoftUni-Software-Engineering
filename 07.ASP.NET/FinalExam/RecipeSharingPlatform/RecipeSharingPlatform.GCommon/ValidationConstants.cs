namespace RecipeSharingPlatform.GCommon
{
    public static class ValidationConstants
    {
        public static class Recipe
        {
            public const int TitleMaxLength = 80;
            public const int TitleMinLength = 3;

            public const int InstructionsMaxLength = 250;
            public const int InstructionsMinLength = 10;

            public const string CreatedOnFormat = "yyyy-MM-dd";
            public const int CreatedOnLength = 10;

            public const string NotModifyMessage = "Please do not modify the page";
            public const string CreateErrorMessage = "Fatal error occurred while creating a recipe";
            public const string DeleteErrorMessage = "Fatal error occurred while deleting the recipe";
            public const string EditErrorMessage = "Fatal error occurred while updating the recipe";
        }

        public static class Category
        {
            public const int NameMaxLength = 20;
            public const int NameMinLength = 3;
        }
    }
}