double r = double.Parse(Console.ReadLine());

// Пресмятаме лицето и периметъра
double area = Math.PI * Math.Pow(r, 2);
double perimeter = 2 * Math.PI * r;

// Форматираме изхода до втория знак след десетичната запетая
string formattedArea = area.ToString("F2");
string formattedPerimeter = perimeter.ToString("F2");

// Отпечатваме резултата
Console.WriteLine(formattedArea);
Console.WriteLine(formattedPerimeter);