using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class RenameStatusToIssueStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Status_IssueStatusId",
                table: "Issues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                table: "Status");

            migrationBuilder.RenameTable(
                name: "Status",
                newName: "IssueStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IssueStatus",
                table: "IssueStatus",
                column: "IssueStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_IssueStatus_IssueStatusId",
                table: "Issues",
                column: "IssueStatusId",
                principalTable: "IssueStatus",
                principalColumn: "IssueStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_IssueStatus_IssueStatusId",
                table: "Issues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IssueStatus",
                table: "IssueStatus");

            migrationBuilder.RenameTable(
                name: "IssueStatus",
                newName: "Status");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                table: "Status",
                column: "IssueStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Status_IssueStatusId",
                table: "Issues",
                column: "IssueStatusId",
                principalTable: "Status",
                principalColumn: "IssueStatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
