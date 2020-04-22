using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UserIdAddedToDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Reporter",
                table: "IssueDetails",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_IssueDetails_Reporter",
                table: "IssueDetails",
                column: "Reporter");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueDetails_AspNetUsers_Reporter",
                table: "IssueDetails",
                column: "Reporter",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueDetails_AspNetUsers_Reporter",
                table: "IssueDetails");

            migrationBuilder.DropIndex(
                name: "IX_IssueDetails_Reporter",
                table: "IssueDetails");

            migrationBuilder.AlterColumn<int>(
                name: "Reporter",
                table: "IssueDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
