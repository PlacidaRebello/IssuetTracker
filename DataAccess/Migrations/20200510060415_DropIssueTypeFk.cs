using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class DropIssueTypeFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_IssueType_IssueTypeId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_IssueTypeId",
                table: "Issues");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Issues_IssueTypeId",
                table: "Issues",
                column: "IssueTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_IssueType_IssueTypeId",
                table: "Issues",
                column: "IssueTypeId",
                principalTable: "IssueType",
                principalColumn: "IssueTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
