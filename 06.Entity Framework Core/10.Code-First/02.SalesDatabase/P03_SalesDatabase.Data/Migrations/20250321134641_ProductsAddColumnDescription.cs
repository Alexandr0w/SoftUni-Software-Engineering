using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P03_SalesDatabase.Data.Migrations
{
    public partial class ProductsAddColumnDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "No description");

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 3, 21, 15, 46, 40, 909, DateTimeKind.Local).AddTicks(6170));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 3, 20, 15, 46, 40, 909, DateTimeKind.Local).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 3, 19, 15, 46, 40, 909, DateTimeKind.Local).AddTicks(6208));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2025, 3, 18, 15, 46, 40, 909, DateTimeKind.Local).AddTicks(6211));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2025, 3, 17, 15, 46, 40, 909, DateTimeKind.Local).AddTicks(6213));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 3, 21, 15, 21, 38, 688, DateTimeKind.Local).AddTicks(1764));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 3, 20, 15, 21, 38, 688, DateTimeKind.Local).AddTicks(1799));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 3, 19, 15, 21, 38, 688, DateTimeKind.Local).AddTicks(1803));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2025, 3, 18, 15, 21, 38, 688, DateTimeKind.Local).AddTicks(1805));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2025, 3, 17, 15, 21, 38, 688, DateTimeKind.Local).AddTicks(1807));
        }
    }
}
