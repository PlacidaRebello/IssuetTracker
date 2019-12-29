using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InsertSprintStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO SprintStatuses(SprintStatusName) Values('Not Started')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
