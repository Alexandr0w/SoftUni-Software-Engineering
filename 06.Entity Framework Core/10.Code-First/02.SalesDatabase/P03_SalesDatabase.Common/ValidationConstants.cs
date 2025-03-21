namespace P03_SalesDatabase.Common
{
    public static class ValidationConstants
    {
        public static class Product
        {
            public const int ProductNameMaxLength = 50;
            public const int ProductDescMaxLength = 250;
            public const string ProductQuantityType = @"decimal(18,2)";
            public const string ProductPriceType = @"decimal(18,2)";
            public const string DefaultProductDescription = @"No description";
        }

        public static class Customer
        {
            public const int CustomerNameMaxLength = 100;
            public const int CustomerEmailMaxLength = 80;
        }

        public static class Store
        {
            public const int StoreNameMaxLength = 50;
        }

        public static class Sale
        {
            public const string DefaultDateValue = @"GETDATE()";
        }
    }
}
