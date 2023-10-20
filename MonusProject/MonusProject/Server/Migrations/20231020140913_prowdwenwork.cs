using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonusProject.Server.Migrations
{
    /// <inheritdoc />
    public partial class prowdwenwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "SedeName",
                table: "Dipendenti");

            migrationBuilder.AddColumn<int>(
                name: "Sede",
                table: "Dipendenti",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dipendenti_Sedi_Sede",
                table: "Dipendenti");

            migrationBuilder.DropIndex(
                name: "IX_Dipendenti_Sede",
                table: "Dipendenti");

            migrationBuilder.DropColumn(
                name: "Sede",
                table: "Dipendenti");

            migrationBuilder.AddColumn<int>(
                name: "SedeId",
                table: "Dipendenti",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SedeName",
                table: "Dipendenti",
                type: "nvarchar(max)",
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
    }
}
