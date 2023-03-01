using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaRental.Server.Migrations
{
    /// <inheritdoc />
    public partial class EditionSeeding3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "1 day" },
                    { 3, "3 day" },
                    { 5, "5 day" }
                });

            migrationBuilder.InsertData(
                table: "CarEdition",
                columns: new[] { "CarsId", "EditionsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 5 },
                    { 2, 1 },
                    { 2, 3 },
                    { 2, 5 },
                    { 3, 1 },
                    { 3, 3 },
                    { 3, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarEdition",
                keyColumns: new[] { "CarsId", "EditionsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CarEdition",
                keyColumns: new[] { "CarsId", "EditionsId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CarEdition",
                keyColumns: new[] { "CarsId", "EditionsId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "CarEdition",
                keyColumns: new[] { "CarsId", "EditionsId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CarEdition",
                keyColumns: new[] { "CarsId", "EditionsId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CarEdition",
                keyColumns: new[] { "CarsId", "EditionsId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "CarEdition",
                keyColumns: new[] { "CarsId", "EditionsId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CarEdition",
                keyColumns: new[] { "CarsId", "EditionsId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CarEdition",
                keyColumns: new[] { "CarsId", "EditionsId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
