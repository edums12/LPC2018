using Microsoft.EntityFrameworkCore.Migrations;

namespace AppChamados.Migrations
{
    public partial class segundaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamado_Solicitante_solicitanteid",
                table: "Chamado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chamado",
                table: "Chamado");

            migrationBuilder.RenameTable(
                name: "Chamado",
                newName: "Chamados");

            migrationBuilder.RenameColumn(
                name: "solicitanteid",
                table: "Chamados",
                newName: "solicitanteId");

            migrationBuilder.RenameIndex(
                name: "IX_Chamado_solicitanteid",
                table: "Chamados",
                newName: "IX_Chamados_solicitanteId");

            migrationBuilder.AlterColumn<int>(
                name: "solicitanteId",
                table: "Chamados",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chamados",
                table: "Chamados",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Solicitante_solicitanteId",
                table: "Chamados",
                column: "solicitanteId",
                principalTable: "Solicitante",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Solicitante_solicitanteId",
                table: "Chamados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chamados",
                table: "Chamados");

            migrationBuilder.RenameTable(
                name: "Chamados",
                newName: "Chamado");

            migrationBuilder.RenameColumn(
                name: "solicitanteId",
                table: "Chamado",
                newName: "solicitanteid");

            migrationBuilder.RenameIndex(
                name: "IX_Chamados_solicitanteId",
                table: "Chamado",
                newName: "IX_Chamado_solicitanteid");

            migrationBuilder.AlterColumn<int>(
                name: "solicitanteid",
                table: "Chamado",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chamado",
                table: "Chamado",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamado_Solicitante_solicitanteid",
                table: "Chamado",
                column: "solicitanteid",
                principalTable: "Solicitante",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
