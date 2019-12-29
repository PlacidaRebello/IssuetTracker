using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ForeigKeyUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SprintStatus",
                table: "Sprints");

            migrationBuilder.AddColumn<int>(
                name: "SprintStatusId",
                table: "Sprints",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SprintStatuses",
                columns: table => new
                {
                    SprintStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SprintStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprintStatuses", x => x.SprintStatusId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SprintStatuses");

            migrationBuilder.DropColumn(
                name: "SprintStatusId",
                table: "Sprints");

            migrationBuilder.AddColumn<int>(
                name: "SprintStatus",
                table: "Sprints",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
