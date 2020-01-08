using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InsertSprintStatusLocal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("INSERT INTO SprintStatuses(SprintStatusName) Values('Not Started')");
            migrationBuilder.Sql("INSERT INTO SprintStatuses(SprintStatusName) Values('In Progress')");
            migrationBuilder.Sql("INSERT INTO SprintStatuses(SprintStatusName) Values('Completed')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
