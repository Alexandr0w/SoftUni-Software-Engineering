int numPages = int.Parse(Console.ReadLine());
int pagesPerHour = int.Parse(Console.ReadLine());
int days = int.Parse(Console.ReadLine());

int time = numPages / pagesPerHour; // общо време за четене на книгите
int hoursPerDay = time / days; // необходиме часове на ден

Console.WriteLine(hoursPerDay);