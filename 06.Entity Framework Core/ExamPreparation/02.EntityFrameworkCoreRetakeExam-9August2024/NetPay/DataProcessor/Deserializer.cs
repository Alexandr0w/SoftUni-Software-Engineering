using NetPay.Data;
using NetPay.Utilities;
using NetPay.Data.Models;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ImportDtos;
using System.Text;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace NetPay.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedHousehold = "Successfully imported household. Contact person: {0}";
        private const string SuccessfullyImportedExpense = "Successfully imported expense. {0}, Amount: {1}";

        public static string ImportHouseholds(NetPayContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            ImportHouseholdDto[]? householdDtos = XmlHelper.Deserialize <ImportHouseholdDto[]>(xmlString, "Households");

            if (householdDtos != null)
            {
                ICollection<Household> dbHousehold = new List<Household>();

                foreach (ImportHouseholdDto householdDto in householdDtos)
                {
                    if (!IsValid(householdDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (ExistInDb(householdDto, dbHousehold))
                    {
                        sb.AppendLine(DuplicationDataMessage);
                        continue;
                    }

                    Household household = new Household
                    {
                        PhoneNumber = householdDto.PhoneNumber,
                        ContactPerson = householdDto.ContactPerson,
                        Email = householdDto.Email
                    };

                    dbHousehold.Add(household);
                    sb.AppendLine(string.Format(SuccessfullyImportedHousehold, household.ContactPerson));
                }

                context.Households.AddRange(dbHousehold);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportExpenses(NetPayContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportExpenseDto[]? expenseDtos = JsonConvert.DeserializeObject<ImportExpenseDto[]>(jsonString);

            if (expenseDtos != null)
            {
                ICollection<Expense> dbExpenses = new List<Expense>();
                foreach (ImportExpenseDto expenseDto in expenseDtos)
                {
                    bool isDueDateValid = DateTime
                        .TryParseExact(expenseDto.DueDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDate);
                    
                    if (!IsValid(expenseDto) || !isDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!context.Households.Any(hh => hh.Id == expenseDto.HouseholdId) || 
                        !context.Services.Any(s => s.Id == expenseDto.ServiceId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Expense expense = new Expense
                    {
                        ExpenseName = expenseDto.ExpenseName,
                        Amount = expenseDto.Amount,
                        DueDate = dueDate,
                        PaymentStatus = Enum.Parse<PaymentStatus>(expenseDto.PaymentStatus),
                        HouseholdId = expenseDto.HouseholdId,
                        ServiceId = expenseDto.ServiceId
                    };

                    dbExpenses.Add(expense);
                    sb.AppendLine(string.Format(SuccessfullyImportedExpense, expense.ExpenseName, expense.Amount.ToString("F2")));
                }
                
                context.Expenses.AddRange(dbExpenses);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        private static bool ExistInDb(ImportHouseholdDto householdDto, ICollection<Household> dbHousehold)
        {
            bool result = dbHousehold.Any(h => h.PhoneNumber == householdDto.PhoneNumber) ||
                          dbHousehold.Any(h => h.ContactPerson == householdDto.ContactPerson) ||
                          dbHousehold.Any(h => h.Email == householdDto.Email);
            return result;
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach(var result in validationResults)
            {
                string currvValidationMessage = result.ErrorMessage!;
            }

            return isValid;
        }
    }
}
