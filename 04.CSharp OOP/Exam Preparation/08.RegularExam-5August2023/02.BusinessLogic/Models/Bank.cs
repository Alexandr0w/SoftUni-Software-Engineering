using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private List<ILoan> _loans;
        private List<IClient> _clients;

        protected Bank(string name, int capacity)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);

            this.Name = name;
            this.Capacity = capacity;

            this._loans = new List<ILoan>();
            this.Loans = this._loans.AsReadOnly();

            this._clients = new List<IClient>();
            this.Clients = this._clients.AsReadOnly();
        }

        public string Name { get; }
        public int Capacity { get; }

        public IReadOnlyCollection<ILoan> Loans { get; }

        public IReadOnlyCollection<IClient> Clients { get; }

        public void AddClient(IClient client)
        {
            if (this.Clients.Count < this.Capacity)
            {
                this._clients.Add(client);
            }
        }

        public void RemoveClient(IClient client) => this._clients.Remove(client);

        public void AddLoan(ILoan loan) => this._loans.Add(loan);

        public double SumRates()
        {
            if (this.Loans.Count == 0)
            {
                return 0;
            }
            return double.Parse(this.Loans.Select(l => l.InterestRate).Sum().ToString());
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {this.Name}, Type: {this.GetType().Name}");
            sb.Append($"Clients: ");

            if (this._clients.Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                string names = string.Join(", ", this._clients.Select(c => c.Name));
                sb.AppendLine(names);
            }

            sb.AppendLine($"Loans: {this._loans.Count}, Sum of Rates: {this.SumRates()}");

            return sb.ToString().TrimEnd();
        }
    }
}
