string text = Console.ReadLine();

for (int i = 0; i < text.Length; i++) // цикъл за дължината на променливата текст
{
    char currentSymbol = text[i]; // вземаме буква (символ) от променливата

    Console.WriteLine(currentSymbol);
}