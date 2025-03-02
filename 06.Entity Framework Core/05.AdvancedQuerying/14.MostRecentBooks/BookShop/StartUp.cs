namespace BookShop
{
    using System.Text;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            string result = GetMostRecentBooks(db);
            Console.WriteLine(result);
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                    .OrderByDescending(b => b.Book.ReleaseDate)
                    .Select(b => new
                    {
                        Title = b.Book.Title,
                        Year = b.Book.ReleaseDate!.Value.Year
                    })
                    .Take(3)
                    .ToArray()
                })
                .ToArray();

            foreach (var c in categories)
            {
                sb.AppendLine($"--{c.Name}");

                if (c.Books.Length > 0)
                {
                    foreach (var b in c.Books)
                    {
                        sb.AppendLine($"{b.Title} ({b.Year})");
                    }
                }
            }

            return sb.ToString().Trim();
        }
    }
}


