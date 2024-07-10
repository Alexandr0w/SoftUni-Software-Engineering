namespace _06.StudentAcademy
{
    internal class Program
    {
        class Student
        {
            public Student(string name)
            {
                Grades = new List<double>();
                Name = name;
            }

            public string Name { get; set; }

            public List<double> Grades { get; set; }

            public override string ToString()
            {

                return $"{Name} -> {Grades.Average():F2}";
            }
        }

        static void Main(string[] args)
        {
            Dictionary<string, Student> students = new Dictionary<string, Student>();
           
            int studentsCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= studentsCount; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName, new Student(studentName));
                }

                students[studentName].Grades.Add(grade);
            }

            var filteredStudents = students.Where(g => g.Value.Grades.Average() >= 4.50);

            foreach (var pair in filteredStudents)
            {
                Console.WriteLine(pair.Value.ToString());
            }
        }
    }
}
