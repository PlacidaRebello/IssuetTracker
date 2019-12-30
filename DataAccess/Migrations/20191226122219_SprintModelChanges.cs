using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DataAccess.Migrations
{
    public partial class SprintModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Sprints_SprintId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_SprintId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "NoOfMembers",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "SprintId",
                table: "Issues");

            migrationBuilder.AlterColumn<decimal>(
                name: "SprintPoints",
                table: "Sprints",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SprintStatus",
                table: "Sprints",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Sprints",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SprintStatus",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Sprints");

            migrationBuilder.AlterColumn<int>(
                name: "SprintPoints",
                table: "Sprints",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "Duration",
                table: "Sprints",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "NoOfMembers",
                table: "Sprints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SprintId",
                table: "Issues",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Issues_SprintId",
                table: "Issues",
                column: "SprintId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Sprints_SprintId",
                table: "Issues",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "SprintId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
