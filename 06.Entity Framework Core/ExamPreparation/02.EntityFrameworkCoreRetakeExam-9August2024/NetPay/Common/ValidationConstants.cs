namespace NetPay.Common
{
    public static class ValidationConstants
    {
        // Household
        public const int ContactPersonMinLength = 5;
        public const int ContactPersonMaxLength = 50;

        public const int EmailMinLength = 6;
        public const int EmailMaxLength = 80;

        public const int PhoneNumberLength = 15;
        public const string PhoneNumberType = @"char(15)";
        public const string PhoneNumberPattern = @"^\+\d{3}/\d{3}-\d{6}$";

        // Expense
        public const int ExpenseNameMinLength = 5;
        public const int ExpenseNameMaxLength = 50;

        public const string ExpenseAmountMin = "0.01";
        public const string ExpenseAmountMax = "100000";

        public const string ExpenseAmountType = "decimal(18,2)";

        // Service
        public const int ServiceNameMinLength = 5;
        public const int ServiceNameMaxLength = 30;

        // Supplier
        public const int SupplierNameMinLength = 3;
        public const int SupplierNameMaxLength = 60;
    }
}