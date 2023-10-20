using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonusProject.Server.Migrations
{
    /// <inheritdoc />
    public partial class add_colloquiosede : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SedeId",
                table: "Colloqui");

            migrationBuilder.AddColumn<string>(
                name: "SedeName",
                table: "Dipendenti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SedeName",
                table: "Colloqui",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SedeName",
                table: "Dipendenti");

            migrationBuilder.DropColumn(
                name: "SedeName",
                table: "Colloqui");

            migrationBuilder.AddColumn<int>(
                name: "SedeId",
                table: "Colloqui",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
