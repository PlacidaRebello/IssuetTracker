using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class StatusNameChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Status_StatusId",
                table: "Issues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Issues_StatusId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Issues");

            migrationBuilder.AddColumn<int>(
                name: "IssueStatusId",
                table: "Status",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IssueStatusId",
                table: "Issues",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                table: "Status",
                column: "IssueStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_IssueStatusId",
                table: "Issues",
                column: "IssueStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Status_IssueStatusId",
                table: "Issues",
                column: "IssueStatusId",
                principalTable: "Status",
                principalColumn: "IssueStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Status_IssueStatusId",
                table: "Issues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Issues_IssueStatusId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "IssueStatusId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "IssueStatusId",
                table: "Issues");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Status",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Issues",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                table: "Status",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_StatusId",
                table: "Issues",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Status_StatusId",
                table: "Issues",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
