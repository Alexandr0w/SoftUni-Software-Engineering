double deposit = int.Parse(Console.ReadLine()); // депозит
int term = int.Parse(Console.ReadLine()); // срок на депозита (в месеци)
double rate =double.Parse(Console.ReadLine())/100; // годишен лихвен процент

double sum = deposit + term * (deposit * rate / 12); // сумата в края на срока

Console.WriteLine(sum);