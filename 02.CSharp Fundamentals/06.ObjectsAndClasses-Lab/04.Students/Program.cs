namespace _04.Students
{
    internal class Program
    {
        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string City { get; set; }
        }
        static void Main(string[] args)
        {
            string[] information = Console.ReadLine().Split(' ');
            List<Student> students = new List<Student>();

            while (information[0] != "end")
            {
                Student student = new Student();
                student.FirstName = information[0];
                student.LastName = information[1];
                student.Age = (int.Parse(information[2]));
                student.City = information[3];

                students.Add(student);

                information = Console.ReadLine().Split(' ');
            }

            string filterCity = Console.ReadLine();

            CheckEveryStudent(students, filterCity);
        }

        static void CheckEveryStudent(List<Student> students, string? filterCity)
        {
            foreach (Student student in students)
            {
                if (student.City == filterCity)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
}
