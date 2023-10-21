using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonusProject.Server.Migrations
{
    /// <inheritdoc />
    public partial class newdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillName",
                table: "Dipendenti");

            migrationBuilder.DropColumn(
                name: "SkillName",
                table: "Candidati");

            migrationBuilder.CreateTable(
                name: "CandidatoSkill",
                columns: table => new
                {
                    CandidatoSkillatoCandidatoId = table.Column<int>(type: "int", nullable: false),
                    SkillCandidatoSkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatoSkill", x => new { x.CandidatoSkillatoCandidatoId, x.SkillCandidatoSkillId });
                    table.ForeignKey(
                        name: "FK_CandidatoSkill_Candidati_CandidatoSkillatoCandidatoId",
                        column: x => x.CandidatoSkillatoCandidatoId,
                        principalTable: "Candidati",
                        principalColumn: "CandidatoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatoSkill_Skills_SkillCandidatoSkillId",
                        column: x => x.SkillCandidatoSkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DipendenteSkill",
                columns: table => new
                {
                    DipendenteSkillatoDipendenteId = table.Column<int>(type: "int", nullable: false),
                    SkillDipendenteSkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DipendenteSkill", x => new { x.DipendenteSkillatoDipendenteId, x.SkillDipendenteSkillId });
                    table.ForeignKey(
                        name: "FK_DipendenteSkill_Dipendenti_DipendenteSkillatoDipendenteId",
                        column: x => x.DipendenteSkillatoDipendenteId,
                        principalTable: "Dipendenti",
                        principalColumn: "DipendenteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DipendenteSkill_Skills_SkillDipendenteSkillId",
                        column: x => x.SkillDipendenteSkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoSkill_SkillCandidatoSkillId",
                table: "CandidatoSkill",
                column: "SkillCandidatoSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_DipendenteSkill_SkillDipendenteSkillId",
                table: "DipendenteSkill",
                column: "SkillDipendenteSkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatoSkill");

            migrationBuilder.DropTable(
                name: "DipendenteSkill");

            migrationBuilder.AddColumn<string>(
                name: "SkillName",
                table: "Dipendenti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SkillName",
                table: "Candidati",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
