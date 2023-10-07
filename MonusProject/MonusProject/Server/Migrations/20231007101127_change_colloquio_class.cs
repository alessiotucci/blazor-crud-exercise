using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonusProject.Server.Migrations
{
    /// <inheritdoc />
    public partial class change_colloquio_class : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Colloqui_CandidatoId",
                table: "Colloqui",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colloqui_DipendenteId",
                table: "Colloqui",
                column: "DipendenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colloqui_Candidati_CandidatoId",
                table: "Colloqui",
                column: "CandidatoId",
                principalTable: "Candidati",
                principalColumn: "CandidatoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Colloqui_Dipendenti_DipendenteId",
                table: "Colloqui",
                column: "DipendenteId",
                principalTable: "Dipendenti",
                principalColumn: "DipendenteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colloqui_Candidati_CandidatoId",
                table: "Colloqui");

            migrationBuilder.DropForeignKey(
                name: "FK_Colloqui_Dipendenti_DipendenteId",
                table: "Colloqui");

            migrationBuilder.DropIndex(
                name: "IX_Colloqui_CandidatoId",
                table: "Colloqui");

            migrationBuilder.DropIndex(
                name: "IX_Colloqui_DipendenteId",
                table: "Colloqui");
        }
    }
}
