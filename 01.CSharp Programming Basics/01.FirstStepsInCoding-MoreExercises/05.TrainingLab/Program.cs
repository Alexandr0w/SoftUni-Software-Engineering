double lenght = double.Parse(Console.ReadLine());  // дължина
double width  = double.Parse(Console.ReadLine()); // ширина

double row = Math.Floor(lenght / 1.20);  // един ред
double col = Math.Floor((width-1) / 0.70);  // една колона

double seats = (row * col) - 3;  // изчисляване на местата

Console.WriteLine(seats);