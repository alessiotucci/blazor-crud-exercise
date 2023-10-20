using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonusProject.Server.Migrations
{
    /// <inheritdoc />
    public partial class add_small_detail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dipendenti_Sedi_SedeId",
                table: "Dipendenti");

            migrationBuilder.AlterColumn<int>(
                name: "SedeId",
                table: "Dipendenti",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SedeName",
                table: "Dipendenti",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.DropColumn(
                name: "SedeName",
                table: "Dipendenti");

            migrationBuilder.AlterColumn<int>(
                name: "SedeId",
                table: "Dipendenti",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dipendenti_Sedi_SedeId",
                table: "Dipendenti",
                column: "SedeId",
                principalTable: "Sedi",
                principalColumn: "SedeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
