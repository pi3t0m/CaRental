using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaRental.Server.Migrations
{
    /// <inheritdoc />
    public partial class CarVariants3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarEdition");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "OrginalPrice",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cars");

            migrationBuilder.CreateTable(
                name: "CarVariant",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    EditionId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    OrginalPrice = table.Column<decimal>(type: "Decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarVariant", x => new { x.CarId, x.EditionId });
                    table.ForeignKey(
                        name: "FK_CarVariant_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarVariant_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Default");

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "1 day" },
                    { 4, "3 day" },
                    { 6, "5 day" }
                });

            migrationBuilder.InsertData(
                table: "CarVariant",
                columns: new[] { "CarId", "EditionId", "OrginalPrice", "Price" },
                values: new object[,]
                {
                    { 1, 2, 1000.00m, 900.00m },
                    { 1, 4, 3000.00m, 2500.00m },
                    { 1, 6, 5000.00m, 4000.00m },
                    { 2, 2, 1000.00m, 900.00m },
                    { 2, 4, 3000.00m, 2500.00m },
                    { 2, 6, 5000.00m, 4000.00m },
                    { 3, 2, 1000.00m, 900.00m },
                    { 3, 4, 3000.00m, 2500.00m },
                    { 3, 6, 5000.00m, 4000.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarVariant_EditionId",
                table: "CarVariant",
                column: "EditionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarVariant");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AddColumn<decimal>(
                name: "OrginalPrice",
                table: "Cars",
                type: "Decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Cars",
                type: "Decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "CarEdition",
                columns: table => new
                {
                    CarsId = table.Column<int>(type: "int", nullable: false),
                    EditionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarEdition", x => new { x.CarsId, x.EditionsId });
                    table.ForeignKey(
                        name: "FK_CarEdition_Cars_CarsId",
                        column: x => x.CarsId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarEdition_Editions_EditionsId",
                        column: x => x.EditionsId,
                        principalTable: "Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CarEdition",
                columns: new[] { "CarsId", "EditionsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OrginalPrice", "Price" },
                values: new object[] { 1000m, 900m });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "OrginalPrice", "Price" },
                values: new object[] { 800m, 700m });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "OrginalPrice", "Price" },
                values: new object[] { 1100m, 1000m });

            migrationBuilder.UpdateData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "1 day");

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "3 day" },
                    { 5, "5 day" }
                });

            migrationBuilder.InsertData(
                table: "CarEdition",
                columns: new[] { "CarsId", "EditionsId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 5 },
                    { 2, 3 },
                    { 2, 5 },
                    { 3, 3 },
                    { 3, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarEdition_EditionsId",
                table: "CarEdition",
                column: "EditionsId");
        }
    }
}
