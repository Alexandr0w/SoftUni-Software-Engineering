namespace _03.SchoolLibrary
{
    internal class Program
    {
        static void Main()
        {
            List<string> books = Console.ReadLine().Split('&').ToList();

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] arguments = command.Split(" | ");
                string action = arguments[0];
                string bookName;

                switch (action)
                {
                    case "Add Book":
                        bookName = arguments[1];
                        if (!books.Contains(bookName))
                        {
                            books.Insert(0, bookName);
                        }
                        break;

                    case "Take Book":
                        bookName = arguments[1];
                        books.Remove(bookName);
                        break;

                    case "Swap Books":
                        string book1 = arguments[1];
                        string book2 = arguments[2];
                        if (books.Contains(book1) && books.Contains(book2))
                        {
                            int index1 = books.IndexOf(book1);
                            int index2 = books.IndexOf(book2);

                            books[index1] = book2;
                            books[index2] = book1;
                        }
                        break;

                    case "Insert Book":
                        bookName = arguments[1];
                        if (!books.Contains(bookName))
                        {
                            books.Add(bookName);
                        }
                        break;

                    case "Check Book":
                        int index = int.Parse(arguments[1]);
                        if (index >= 0 && index < books.Count)
                        {
                            Console.WriteLine(books[index]);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", books));
        }
    }
}
