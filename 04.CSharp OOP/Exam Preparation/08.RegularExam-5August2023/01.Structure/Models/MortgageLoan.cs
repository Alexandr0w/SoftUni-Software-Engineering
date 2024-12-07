namespace BankLoan.Models
{
    public class MortgageLoan : Loan
    {
        private const int interestRate = 3;
        private const int amount = 50000;

        public MortgageLoan() : base(interestRate, amount)
        {
        }
    }
}
