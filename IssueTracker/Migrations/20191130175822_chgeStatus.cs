using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTracker.Migrations
{
    public partial class chgeStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Status_Issues_IssueId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Status_IssueId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "IssueId",
                table: "Status");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Issues",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Status_StatusId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_StatusId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Issues");

            migrationBuilder.AddColumn<int>(
                name: "IssueId",
                table: "Status",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Status_IssueId",
                table: "Status",
                column: "IssueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Issues_IssueId",
                table: "Status",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "IssueId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
