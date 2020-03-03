using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class FkStatusIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_IssueStatus_IssueStatusId",
                table: "Issues");

            migrationBuilder.AlterColumn<int>(
                name: "IssueStatusId",
                table: "Issues",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_IssueStatus_IssueStatusId",
                table: "Issues",
                column: "IssueStatusId",
                principalTable: "IssueStatus",
                principalColumn: "IssueStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_IssueStatus_IssueStatusId",
                table: "Issues");

            migrationBuilder.AlterColumn<int>(
                name: "IssueStatusId",
                table: "Issues",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_IssueStatus_IssueStatusId",
                table: "Issues",
                column: "IssueStatusId",
                principalTable: "IssueStatus",
                principalColumn: "IssueStatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
