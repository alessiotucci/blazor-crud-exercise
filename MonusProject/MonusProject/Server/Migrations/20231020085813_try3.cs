using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonusProject.Server.Migrations
{
    /// <inheritdoc />
    public partial class try3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SedeName",
                table: "Dipendenti");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SedeName",
                table: "Dipendenti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
