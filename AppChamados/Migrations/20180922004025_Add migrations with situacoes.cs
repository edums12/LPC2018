using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AppChamados.Migrations
{
    public partial class Addmigrationswithsituacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "situacaoId",
                table: "Chamados",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Situacoes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacoes", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_situacaoId",
                table: "Chamados",
                column: "situacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Situacoes_situacaoId",
                table: "Chamados",
                column: "situacaoId",
                principalTable: "Situacoes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Situacoes_situacaoId",
                table: "Chamados");

            migrationBuilder.DropTable(
                name: "Situacoes");

            migrationBuilder.DropIndex(
                name: "IX_Chamados_situacaoId",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "situacaoId",
                table: "Chamados");
        }
    }
}
