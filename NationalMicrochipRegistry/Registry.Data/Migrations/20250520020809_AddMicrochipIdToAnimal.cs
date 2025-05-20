using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registry.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMicrochipIdToAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Microchips_Animals_AnimalId",
                table: "Microchips");

            migrationBuilder.DropIndex(
                name: "IX_Microchips_AnimalId",
                table: "Microchips");

            migrationBuilder.AddColumn<int>(
                name: "MicrochipId",
                table: "Microchips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MicrochipId",
                table: "Animals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animals_MicrochipId",
                table: "Animals",
                column: "MicrochipId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Microchips_MicrochipId",
                table: "Animals",
                column: "MicrochipId",
                principalTable: "Microchips",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Microchips_MicrochipId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_MicrochipId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "MicrochipId",
                table: "Microchips");

            migrationBuilder.DropColumn(
                name: "MicrochipId",
                table: "Animals");

            migrationBuilder.CreateIndex(
                name: "IX_Microchips_AnimalId",
                table: "Microchips",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Microchips_Animals_AnimalId",
                table: "Microchips",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id");
        }
    }
}
