namespace BookShop
{
    using Data;
    using Initializer;
    using Models.Enums;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            string result = string.Empty;

            bool isEnumValid = Enum.TryParse(command, true, out AgeRestriction ageRestriction);

            if (!isEnumValid)
            {
                return result;
            }

            var bookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            result = string.Join(Environment.NewLine, bookTitles);

            return result;
        }
    }
}


