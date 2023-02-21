using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaRental.Server.Migrations
{
    /// <inheritdoc />
    public partial class CarsRemoveFromCategoryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 2, 21, 1, 3, 11, 72, DateTimeKind.Local).AddTicks(5120));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 2, 21, 1, 3, 11, 72, DateTimeKind.Local).AddTicks(5158));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 2, 21, 1, 3, 11, 72, DateTimeKind.Local).AddTicks(5161));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 2, 21, 0, 40, 24, 996, DateTimeKind.Local).AddTicks(8468));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 2, 21, 0, 40, 24, 996, DateTimeKind.Local).AddTicks(8508));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 2, 21, 0, 40, 24, 996, DateTimeKind.Local).AddTicks(8511));
        }
    }
}
