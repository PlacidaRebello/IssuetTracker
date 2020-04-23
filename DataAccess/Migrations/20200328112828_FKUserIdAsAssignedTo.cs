using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class FKUserIdAsAssignedTo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AssignedTo",
                table: "Issues",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Issues_AssignedTo",
                table: "Issues",
                column: "AssignedTo");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_AspNetUsers_AssignedTo",
                table: "Issues",
                column: "AssignedTo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_AspNetUsers_AssignedTo",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_AssignedTo",
                table: "Issues");

            migrationBuilder.AlterColumn<string>(
                name: "AssignedTo",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
