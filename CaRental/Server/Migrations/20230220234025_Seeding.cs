using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaRental.Server.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Icon", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "plus", "Exclusives", "exclusive" },
                    { 2, "plus", "Sports", "sport" },
                    { 3, "plus", "Oldschool", "oldschool" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "CategoryId", "DateCreated", "DateUpdated", "Description", "Image", "IsDeleted", "IsPublic", "OrginalPrice", "Price" },
                values: new object[,]
                {
                    { 1, "Maybach", 1, new DateTime(2023, 2, 21, 0, 40, 24, 996, DateTimeKind.Local).AddTicks(8468), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "W223", "https://www.premiumfelgi.pl/userdata/gfx/57200.jpg", false, false, 1000m, 900m },
                    { 2, "Mercedes", 2, new DateTime(2023, 2, 21, 0, 40, 24, 996, DateTimeKind.Local).AddTicks(8508), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AMG GT 63 S E 4-door", "https://motofilm.pl/wp-content/uploads/2022/02/Mercedes-AMG-GT-63-S-E-Performance-4-Drzwiowe-Coupe-1.jpg", false, false, 800m, 700m },
                    { 3, "Mercedes", 3, new DateTime(2023, 2, 21, 0, 40, 24, 996, DateTimeKind.Local).AddTicks(8511), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SL500", "https://images8.alphacoders.com/114/1142237.jpg", false, false, 1100m, 1000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
