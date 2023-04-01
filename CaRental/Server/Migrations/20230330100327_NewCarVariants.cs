using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaRental.Server.Migrations
{
    /// <inheritdoc />
    public partial class NewCarVariants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarVariant_Cars_CarId",
                table: "CarVariant");

            migrationBuilder.DropForeignKey(
                name: "FK_CarVariant_Editions_EditionId",
                table: "CarVariant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarVariant",
                table: "CarVariant");

            migrationBuilder.RenameTable(
                name: "CarVariant",
                newName: "CarVariants");

            migrationBuilder.RenameIndex(
                name: "IX_CarVariant_EditionId",
                table: "CarVariants",
                newName: "IX_CarVariants_EditionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarVariants",
                table: "CarVariants",
                columns: new[] { "CarId", "EditionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CarVariants_Cars_CarId",
                table: "CarVariants",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarVariants_Editions_EditionId",
                table: "CarVariants",
                column: "EditionId",
                principalTable: "Editions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarVariants_Cars_CarId",
                table: "CarVariants");

            migrationBuilder.DropForeignKey(
                name: "FK_CarVariants_Editions_EditionId",
                table: "CarVariants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarVariants",
                table: "CarVariants");

            migrationBuilder.RenameTable(
                name: "CarVariants",
                newName: "CarVariant");

            migrationBuilder.RenameIndex(
                name: "IX_CarVariants_EditionId",
                table: "CarVariant",
                newName: "IX_CarVariant_EditionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarVariant",
                table: "CarVariant",
                columns: new[] { "CarId", "EditionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CarVariant_Cars_CarId",
                table: "CarVariant",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarVariant_Editions_EditionId",
                table: "CarVariant",
                column: "EditionId",
                principalTable: "Editions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
