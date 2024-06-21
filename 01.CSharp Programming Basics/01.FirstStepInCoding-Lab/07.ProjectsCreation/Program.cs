string firstName = Console.ReadLine();
int projects = int.Parse(Console.ReadLine());

double hoursPerProject = 3;
double finalTime = projects * hoursPerProject;

Console.WriteLine($"The architect {firstName} will need {finalTime} hours to complete {projects} project/s.");