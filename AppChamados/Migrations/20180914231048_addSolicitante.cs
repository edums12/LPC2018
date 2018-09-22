using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AppChamados.Migrations
{
    public partial class addSolicitante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Chamado");

            migrationBuilder.DropColumn(
                name: "nome",
                table: "Chamado");

            migrationBuilder.DropColumn(
                name: "telefone",
                table: "Chamado");

            migrationBuilder.AddColumn<int>(
                name: "solicitanteid",
                table: "Chamado",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Solicitante",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nome = table.Column<string>(nullable: true),
                    email = table.Column<List<string>>(nullable: true),
                    telefone = table.Column<List<string>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitante", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_solicitanteid",
                table: "Chamado",
                column: "solicitanteid");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamado_Solicitante_solicitanteid",
                table: "Chamado",
                column: "solicitanteid",
                principalTable: "Solicitante",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamado_Solicitante_solicitanteid",
                table: "Chamado");

            migrationBuilder.DropTable(
                name: "Solicitante");

            migrationBuilder.DropIndex(
                name: "IX_Chamado_solicitanteid",
                table: "Chamado");

            migrationBuilder.DropColumn(
                name: "solicitanteid",
                table: "Chamado");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Chamado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nome",
                table: "Chamado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "telefone",
                table: "Chamado",
                nullable: true);
        }
    }
}
