using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class SprintStatusFkAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SprintStatusId",
                table: "Sprints",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_SprintStatusId",
                table: "Sprints",
                column: "SprintStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_SprintStatuses_SprintStatusId",
                table: "Sprints",
                column: "SprintStatusId",
                principalTable: "SprintStatuses",
                principalColumn: "SprintStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_SprintStatuses_SprintStatusId",
                table: "Sprints");

            migrationBuilder.DropIndex(
                name: "IX_Sprints_SprintStatusId",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "SprintStatusId",
                table: "Sprints");
        }
    }
}
