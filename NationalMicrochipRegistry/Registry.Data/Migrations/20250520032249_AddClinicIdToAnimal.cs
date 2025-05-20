using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registry.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddClinicIdToAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Animals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Animals");
        }
    }
}
