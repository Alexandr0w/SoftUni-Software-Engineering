using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P03_SalesDatabase.Data.Migrations
{
    public partial class InitialSeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CreditCardNumber", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "1234567890123456", "ivan@example.com", "Ivan Petrov" },
                    { 2, "9876543210987654", "maria@example.com", "Maria Ivanova" },
                    { 3, "4567891234567890", "georgi@example.com", "Georgi Dimitrov" },
                    { 4, "1122334455667788", "elena@example.com", "Elena Todorova" },
                    { 5, "6677889900112233", "petar@example.com", "Petar Vasilev" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Laptop", 1200.99m, 5m },
                    { 2, "Mouse", 25.50m, 15m },
                    { 3, "Keyboard", 45.99m, 10m },
                    { 4, "Monitor", 200.00m, 7m },
                    { 5, "Headphones", 75.80m, 20m }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Name" },
                values: new object[,]
                {
                    { 1, "Tech Store Sofia" },
                    { 2, "ElectroMart Plovdiv" },
                    { 3, "Gadget House Varna" },
                    { 4, "Best Buy Burgas" },
                    { 5, "Digital World Ruse" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SaleId", "CustomerId", "Date", "ProductId", "StoreId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2025, 3, 21, 15, 21, 38, 688, DateTimeKind.Local).AddTicks(1764), 1, 3 },
                    { 2, 1, new DateTime(2025, 3, 20, 15, 21, 38, 688, DateTimeKind.Local).AddTicks(1799), 3, 2 },
                    { 3, 5, new DateTime(2025, 3, 19, 15, 21, 38, 688, DateTimeKind.Local).AddTicks(1803), 2, 4 },
                    { 4, 3, new DateTime(2025, 3, 18, 15, 21, 38, 688, DateTimeKind.Local).AddTicks(1805), 4, 1 },
                    { 5, 4, new DateTime(2025, 3, 17, 15, 21, 38, 688, DateTimeKind.Local).AddTicks(1807), 5, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 5);
        }
    }
}
