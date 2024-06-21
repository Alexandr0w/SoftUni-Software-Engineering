// Четене на входните данни
int V = int.Parse(Console.ReadLine()); // Обем на басейна
int P1 = int.Parse(Console.ReadLine()); // Дебит на първата тръба
int P2 = int.Parse(Console.ReadLine()); // Дебит на втората тръба
double H = double.Parse(Console.ReadLine()); // Часове отсъствие на работника

// Изчисляване на общия дебит на водата
double totalFlow = (P1 * H) + (P2 * H); // Произведението на дебитите по времето

// Проверка дали басейнът се е препълнил
if (totalFlow <= V)
{
    double percentFilled = Math.Floor((totalFlow / V) * 100); // Процент запълненост
    double percentPipe1 = Math.Floor((P1 * H / totalFlow) * 100); // Процент вода от първата тръба
    double percentPipe2 = Math.Floor((P2 * H / totalFlow) * 100); // Процент вода от втората тръба

    // Отпечатване на състоянието на басейна
    Console.WriteLine($"The pool is {percentFilled}% full. Pipe 1: {percentPipe1}%. Pipe 2: {percentPipe2}%.");
}
else
{
    // Пресмятане на литрите вода в повече
    double overflowLiters = totalFlow - V;
    double hoursFilled = Math.Ceiling((double)V / (P1 + P2)); // Часове, през които тръбите са пълнили вода

    // Отпечатване на съобщението за препълване
    Console.WriteLine($"For {hoursFilled} hours, the pool overflows with {overflowLiters} liters.");
}