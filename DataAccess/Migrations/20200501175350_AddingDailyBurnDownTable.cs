using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddingDailyBurnDownTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyBurnDown",
                columns: table => new
                {
                    DailyBurnDownId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SprintId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    PointsCompleted = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PointsPending = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyBurnDown", x => x.DailyBurnDownId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyBurnDown");
        }
    }
}
