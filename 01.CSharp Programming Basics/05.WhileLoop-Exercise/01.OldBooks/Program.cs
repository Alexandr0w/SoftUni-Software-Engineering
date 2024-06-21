string favouriteBook = Console.ReadLine();
int count = 0;
string input = Console.ReadLine();

while (input != "No More Books")
{ 
    if(input == favouriteBook)
    {
        Console.WriteLine($"You checked {count} books and found it.");
        break;
    }
    count++;    
    input = Console.ReadLine();
}
if (input == "No More Books")
{
    Console.WriteLine("The book you search is not here!");
    Console.WriteLine($"You checked {count} books.");
}