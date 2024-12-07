using System;
using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;

namespace BankLoan.Models
{
    public abstract class Client : IClient
    {
        public Client(string name, string id, int interest, double income)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.ClientNameNullOrWhitespace);
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException(ExceptionMessages.ClientIdNullOrWhitespace);
            if (income <= 0) throw new ArgumentException(ExceptionMessages.ClientIncomeBelowZero);

            Name = name;
            Id = id;
            Interest = interest;
            Income = income;
        }

        public string Name { get; }
        public string Id { get; }
        public int Interest { get; protected set; }
        public double Income { get; }

        public abstract void IncreaseInterest();
    }
}
