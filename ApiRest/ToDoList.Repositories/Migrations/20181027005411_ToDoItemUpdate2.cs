using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ToDoList.Repositories.Migrations
{
    public partial class ToDoItemUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodosItem_Todos_ToDoid",
                table: "TodosItem");

            migrationBuilder.AlterColumn<int>(
                name: "ToDoid",
                table: "TodosItem",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TodosItem_Todos_ToDoid",
                table: "TodosItem",
                column: "ToDoid",
                principalTable: "Todos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodosItem_Todos_ToDoid",
                table: "TodosItem");

            migrationBuilder.AlterColumn<int>(
                name: "ToDoid",
                table: "TodosItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TodosItem_Todos_ToDoid",
                table: "TodosItem",
                column: "ToDoid",
                principalTable: "Todos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
