using System;
using System.Linq;
using System.Text;
using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using BankLoan.Utilities.Messages;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private IRepository<ILoan> _loans;
        private IRepository<IBank> _banks;

        public Controller()
        {
            this._loans = new LoanRepository();
            this._banks = new BankRepository();
        }

        public string AddBank(string bankTypeName, string name)
        {
            IBank bank;
            if (bankTypeName == nameof(BranchBank))
            {
                bank = new BranchBank(name);
            }
            else if (bankTypeName == nameof(CentralBank))
            {
                bank = new CentralBank(name);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
            }

            this._banks.AddModel(bank);

            return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
        }

        public string AddLoan(string loanTypeName)
        {
            ILoan loan;
            if (loanTypeName == nameof(MortgageLoan))
            {
                loan = new MortgageLoan();
            }
            else if (loanTypeName == nameof(StudentLoan))
            {
                loan = new StudentLoan();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
            }

            this._loans.AddModel(loan);

            return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            ILoan loan = this._loans.FirstModel(loanTypeName);
            IBank bank = this._banks.FirstModel(bankName);

            if (loan == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
            }

            bank.AddLoan(loan);
            this._loans.RemoveModel(loan);

            return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            IClient client;
            if (clientTypeName == nameof(Adult))
            {
                client = new Adult(clientName, id, income);
            }
            else if (clientTypeName == nameof(Student))
            {
                client = new Student(clientName, id, income);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
            }

            IBank bank = this._banks.FirstModel(bankName);

            if ((bank.GetType().Name == nameof(BranchBank) && clientTypeName != nameof(Student)) ||
                (bank.GetType().Name == nameof(CentralBank) && clientTypeName != nameof(Adult)))
            {
                return string.Format(OutputMessages.UnsuitableBank);
            }
            else
            {
                bank.AddClient(client);
            }

            return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
        }

        public string FinalCalculation(string bankName)
        {
            IBank bank = this._banks.Models.FirstOrDefault(b => b.Name == bankName);

            double sumLoans = bank.Loans.Sum(l => l.Amount);
            double sumClients = bank.Clients.Sum(c => c.Income);
            string funds = (sumLoans + sumClients).ToString("0.00");

            return string.Format(OutputMessages.BankFundsCalculated, bankName, funds);
        }

        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var bank in this._banks.Models)
            {
                sb.AppendLine(bank.GetStatistics());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
