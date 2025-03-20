using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetPay.Migrations
{
    public partial class InitialSeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "ServiceName" },
                values: new object[,]
                {
                    { 1, "Electricity" },
                    { 2, "Water" },
                    { 3, "Internet" },
                    { 4, "TV" },
                    { 5, "Phone" },
                    { 6, "Security" },
                    { 7, "Gas" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "SupplierName" },
                values: new object[,]
                {
                    { 1, "E-Service" },
                    { 2, "Light" },
                    { 3, "Energy-PRO" },
                    { 4, "ZEC" },
                    { 5, "Cellular" },
                    { 6, "A2one" },
                    { 7, "Telecom" },
                    { 8, "Cell2U" },
                    { 9, "DigiTV" },
                    { 10, "NetCom" },
                    { 11, "Net1" },
                    { 12, "MaxTel" },
                    { 13, "WaterSupplyCentral" },
                    { 14, "WaterSupplyNorth" },
                    { 15, "WaterSupplySouth" },
                    { 16, "FiberScreen" },
                    { 17, "SpeedNet" },
                    { 18, "GasGas" },
                    { 19, "BlueHome" },
                    { 20, "SecureHouse" },
                    { 21, "HomeGuard" },
                    { 22, "SafeHome" }
                });

            migrationBuilder.InsertData(
                table: "SuppliersServices",
                columns: new[] { "ServiceId", "SupplierId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 3, 5 },
                    { 4, 5 },
                    { 5, 5 },
                    { 3, 6 },
                    { 4, 6 },
                    { 5, 6 },
                    { 6, 6 },
                    { 3, 7 },
                    { 4, 7 },
                    { 5, 7 },
                    { 3, 8 },
                    { 4, 8 },
                    { 5, 8 },
                    { 3, 9 },
                    { 4, 9 },
                    { 3, 10 },
                    { 4, 10 },
                    { 6, 10 },
                    { 3, 11 },
                    { 4, 11 },
                    { 3, 12 },
                    { 4, 12 },
                    { 5, 12 },
                    { 6, 12 },
                    { 2, 13 },
                    { 2, 14 },
                    { 2, 15 },
                    { 3, 16 },
                    { 4, 16 },
                    { 3, 17 },
                    { 4, 17 },
                    { 6, 17 },
                    { 7, 18 },
                    { 7, 19 },
                    { 6, 20 },
                    { 6, 21 },
                    { 6, 22 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 6, 10 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 3, 11 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 3, 12 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 4, 12 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 5, 12 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 6, 12 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 2, 13 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 2, 14 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 2, 15 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 3, 16 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 4, 16 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 3, 17 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 4, 17 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 6, 17 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 7, 18 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 7, 19 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 6, 20 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 6, 21 });

            migrationBuilder.DeleteData(
                table: "SuppliersServices",
                keyColumns: new[] { "ServiceId", "SupplierId" },
                keyValues: new object[] { 6, 22 });

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 22);
        }
    }
}
