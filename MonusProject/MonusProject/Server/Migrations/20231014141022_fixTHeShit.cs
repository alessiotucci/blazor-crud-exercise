using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonusProject.Server.Migrations
{
    /// <inheritdoc />
    public partial class fixTHeShit : Migration
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
                    CandidatiSkillatiCandidatoId = table.Column<int>(type: "int", nullable: false),
                    SkillsSkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatoSkill", x => new { x.CandidatiSkillatiCandidatoId, x.SkillsSkillId });
                    table.ForeignKey(
                        name: "FK_CandidatoSkill_Candidati_CandidatiSkillatiCandidatoId",
                        column: x => x.CandidatiSkillatiCandidatoId,
                        principalTable: "Candidati",
                        principalColumn: "CandidatoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatoSkill_Skills_SkillsSkillId",
                        column: x => x.SkillsSkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DipendenteSkill",
                columns: table => new
                {
                    DipendentiSkillatiDipendenteId = table.Column<int>(type: "int", nullable: false),
                    SkillsSkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DipendenteSkill", x => new { x.DipendentiSkillatiDipendenteId, x.SkillsSkillId });
                    table.ForeignKey(
                        name: "FK_DipendenteSkill_Dipendenti_DipendentiSkillatiDipendenteId",
                        column: x => x.DipendentiSkillatiDipendenteId,
                        principalTable: "Dipendenti",
                        principalColumn: "DipendenteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DipendenteSkill_Skills_SkillsSkillId",
                        column: x => x.SkillsSkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoSkill_SkillsSkillId",
                table: "CandidatoSkill",
                column: "SkillsSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_DipendenteSkill_SkillsSkillId",
                table: "DipendenteSkill",
                column: "SkillsSkillId");
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
