using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemDAL.Migrations
{
    public partial class Initia3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaKnowledge");

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Knowledges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Knowledges_AreaId",
                table: "Knowledges",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Knowledges_Areas_AreaId",
                table: "Knowledges",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knowledges_Areas_AreaId",
                table: "Knowledges");

            migrationBuilder.DropIndex(
                name: "IX_Knowledges_AreaId",
                table: "Knowledges");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Knowledges");

            migrationBuilder.CreateTable(
                name: "AreaKnowledge",
                columns: table => new
                {
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    KnowledgesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaKnowledge", x => new { x.AreaId, x.KnowledgesId });
                    table.ForeignKey(
                        name: "FK_AreaKnowledge_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaKnowledge_Knowledges_KnowledgesId",
                        column: x => x.KnowledgesId,
                        principalTable: "Knowledges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaKnowledge_KnowledgesId",
                table: "AreaKnowledge",
                column: "KnowledgesId");
        }
    }
}
