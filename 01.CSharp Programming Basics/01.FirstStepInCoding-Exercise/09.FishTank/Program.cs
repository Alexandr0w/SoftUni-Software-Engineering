int lenght = int.Parse(Console.ReadLine()); // дължина
int width  = int.Parse(Console.ReadLine()); // ширина
int height = int.Parse(Console.ReadLine()); // височина
double percent = double.Parse(Console.ReadLine());

int volAquarium = lenght * width * height; // обем аквариум
double volLiters = volAquarium * 0.001; // обем в литри
double NeedLiters = volLiters * (1 - percent/100); // нужни литри

Console.WriteLine(NeedLiters);