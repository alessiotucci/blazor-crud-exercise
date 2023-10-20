using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonusProject.Server.Migrations
{
    /// <inheritdoc />
    public partial class rk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SedeDipendete",
                table: "Dipendenti",
                newName: "Seden");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Seden",
                table: "Dipendenti",
                newName: "SedeDipendete");
        }
    }
}
