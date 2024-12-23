namespace DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<Employee> _employees;

        public DetailsPrinter(IList<Employee> employees)
        {
            this._employees = employees;
        }

        public void PrintDetails()
        {
            foreach (Employee employee in this._employees)
            {
                Print(employee);
            }
        }

        private void Print(Employee employee)
        {
            employee.Print();
        }
    }
}
