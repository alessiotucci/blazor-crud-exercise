using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonusProject.Server.Migrations
{
    /// <inheritdoc />
    public partial class pwenwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dipendenti_Sedi_Sede",
                table: "Dipendenti");

            migrationBuilder.DropIndex(
                name: "IX_Dipendenti_Sede",
                table: "Dipendenti");

            migrationBuilder.RenameColumn(
                name: "Sede",
                table: "Dipendenti",
                newName: "SedeDipendete");

            migrationBuilder.AddColumn<int>(
                name: "SedeId",
                table: "Dipendenti",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dipendenti_SedeId",
                table: "Dipendenti",
                column: "SedeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dipendenti_Sedi_SedeId",
                table: "Dipendenti",
                column: "SedeId",
                principalTable: "Sedi",
                principalColumn: "SedeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dipendenti_Sedi_SedeId",
                table: "Dipendenti");

            migrationBuilder.DropIndex(
                name: "IX_Dipendenti_SedeId",
                table: "Dipendenti");

            migrationBuilder.DropColumn(
                name: "SedeId",
                table: "Dipendenti");

            migrationBuilder.RenameColumn(
                name: "SedeDipendete",
                table: "Dipendenti",
                newName: "Sede");

            migrationBuilder.CreateIndex(
                name: "IX_Dipendenti_Sede",
                table: "Dipendenti",
                column: "Sede");

            migrationBuilder.AddForeignKey(
                name: "FK_Dipendenti_Sedi_Sede",
                table: "Dipendenti",
                column: "Sede",
                principalTable: "Sedi",
                principalColumn: "SedeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
