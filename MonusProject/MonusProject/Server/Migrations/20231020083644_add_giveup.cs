using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonusProject.Server.Migrations
{
    /// <inheritdoc />
    public partial class add_giveup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dipendenti_Sedi_SedeDipendenteSedeId",
                table: "Dipendenti");

            migrationBuilder.DropIndex(
                name: "IX_Dipendenti_SedeDipendenteSedeId",
                table: "Dipendenti");

            migrationBuilder.DropColumn(
                name: "SedeDipendenteSedeId",
                table: "Dipendenti");

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

            migrationBuilder.AddColumn<int>(
                name: "SedeDipendenteSedeId",
                table: "Dipendenti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dipendenti_SedeDipendenteSedeId",
                table: "Dipendenti",
                column: "SedeDipendenteSedeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dipendenti_Sedi_SedeDipendenteSedeId",
                table: "Dipendenti",
                column: "SedeDipendenteSedeId",
                principalTable: "Sedi",
                principalColumn: "SedeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
