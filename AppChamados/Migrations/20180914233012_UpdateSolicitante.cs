using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppChamados.Migrations
{
    public partial class UpdateSolicitante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "telefone",
                table: "Solicitante",
                nullable: true,
                oldClrType: typeof(List<string>),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Solicitante",
                nullable: true,
                oldClrType: typeof(List<string>),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<List<string>>(
                name: "telefone",
                table: "Solicitante",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<List<string>>(
                name: "email",
                table: "Solicitante",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
