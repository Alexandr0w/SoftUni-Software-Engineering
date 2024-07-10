namespace _07.CompanyUsers
{
    internal class Program
    {
        class Company
        {
            public string Name;

            public List<string> EmployeeIds;

            public Company(string companyName)
            {
                Name = companyName;
                EmployeeIds = new List<string>();
            }

            public override string ToString()
            {
                string result = string.Empty;

                result += $"{Name}\n";

                foreach (string employeeId in EmployeeIds)
                {
                    result += $"-- {employeeId}\n";
                }
                return result.Trim();
            }
        }

        static void Main(string[] args)
        {
            Dictionary<string, Company> companiesDict = new();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input.Split(" -> ");

                string companyName = arguments[0];
                string employeeId = arguments[1];

                if (!companiesDict.ContainsKey(companyName))
                {
                    companiesDict.Add(companyName, new Company(companyName));
                }

                if (!companiesDict[companyName].EmployeeIds.Contains(employeeId))
                {
                    companiesDict[companyName].EmployeeIds.Add(employeeId);
                }
            }

            foreach (Company company in companiesDict.Values)
            {
                Console.WriteLine(company);
            }
        }
    }
}
