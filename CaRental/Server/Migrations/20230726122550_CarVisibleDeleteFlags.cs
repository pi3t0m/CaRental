using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaRental.Server.Migrations
{
    /// <inheritdoc />
    public partial class CarVisibleDeleteFlags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "CarVariants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "CarVariants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "CarVariants",
                keyColumns: new[] { "CarId", "EditionId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "CarVariants",
                keyColumns: new[] { "CarId", "EditionId" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "CarVariants",
                keyColumns: new[] { "CarId", "EditionId" },
                keyValues: new object[] { 1, 6 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "CarVariants",
                keyColumns: new[] { "CarId", "EditionId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "CarVariants",
                keyColumns: new[] { "CarId", "EditionId" },
                keyValues: new object[] { 2, 4 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "CarVariants",
                keyColumns: new[] { "CarId", "EditionId" },
                keyValues: new object[] { 2, 6 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "CarVariants",
                keyColumns: new[] { "CarId", "EditionId" },
                keyValues: new object[] { 3, 2 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "CarVariants",
                keyColumns: new[] { "CarId", "EditionId" },
                keyValues: new object[] { 3, 4 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "CarVariants",
                keyColumns: new[] { "CarId", "EditionId" },
                keyValues: new object[] { 3, 6 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "CarVariants");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "CarVariants");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "Cars");
        }
    }
}
