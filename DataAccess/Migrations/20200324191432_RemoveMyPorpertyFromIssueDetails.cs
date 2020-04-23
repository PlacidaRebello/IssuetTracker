using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class RemoveMyPorpertyFromIssueDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "IssueDetails");

            migrationBuilder.RenameColumn(
                name: "TImeTracking",
                table: "IssueDetails",
                newName: "TimeTracking");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeTracking",
                table: "IssueDetails",
                newName: "TImeTracking");

            migrationBuilder.AddColumn<bool>(
                name: "MyProperty",
                table: "IssueDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
