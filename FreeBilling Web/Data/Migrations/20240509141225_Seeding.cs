using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FreeBilling.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AddressLine3", "City", "Country", "PostalCode", "StateProvince" },
                values: new object[,]
                {
                    { 1, "123 Main Avenue", null, null, null, null, "4625378", "Atlanta" },
                    { 2, "123 First Avenue", null, null, null, null, "123345", "GA" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BillingRate", "Email", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, 115.0, "kuken@Johnson.com", "/img/kuken.jpg", "Kuken Johnson" },
                    { 2, 215.0, "balla@jalla.com", "/img/balla.jpg", "Balla Jalla" },
                    { 3, 110.0, "pinna@PinnaK.com", "/img/pinna.jpg", "Pinna Kristiansen" },
                    { 4, 234.0, "klys@klausen.com", "/img/.kkp.jpg", "Klysa Klausen" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "CompanyName", "Contact", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "Smith Towing", "Jim", null },
                    { 2, 2, "Anker AS", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
