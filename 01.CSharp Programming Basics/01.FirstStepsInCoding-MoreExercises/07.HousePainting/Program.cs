double xHeight = double.Parse(Console.ReadLine()); 
double yWidth = double.Parse(Console.ReadLine());
double hTriangle = double.Parse(Console.ReadLine());

double areaRectangle = ((xHeight * yWidth) * 2) - (2 * (1.5 * 1.5));  // лице на правоъгълник
double areaSquare = ((xHeight * xHeight) * 2) - (1.2 * 2);  // лице на квадрат
double areaTriangleTop = ((xHeight * hTriangle) / 2) * 2; // лице на триъгълник най-отгоре
double areaRectangleTop = (xHeight * yWidth) * 2; // лице на правоъгълника най-отгоре

double paintRed = (areaTriangleTop + areaRectangleTop) / 4.3; // нужната червена боя
double paintGreen = (areaRectangle + areaSquare) / 3.4; // нужната зелена боя

Console.WriteLine($"{paintGreen:f2}");
Console.WriteLine($"{paintRed:f2}");
