using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class CreatingReleaseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReleaseId",
                table: "Sprints",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Release",
                columns: table => new
                {
                    ReleaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReleaseName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    SprintStatusId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Release", x => x.ReleaseId);
                    table.ForeignKey(
                        name: "FK_Release_SprintStatuses_SprintStatusId",
                        column: x => x.SprintStatusId,
                        principalTable: "SprintStatuses",
                        principalColumn: "SprintStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_ReleaseId",
                table: "Sprints",
                column: "ReleaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Release_SprintStatusId",
                table: "Release",
                column: "SprintStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Release_ReleaseId",
                table: "Sprints",
                column: "ReleaseId",
                principalTable: "Release",
                principalColumn: "ReleaseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Release_ReleaseId",
                table: "Sprints");

            migrationBuilder.DropTable(
                name: "Release");

            migrationBuilder.DropIndex(
                name: "IX_Sprints_ReleaseId",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "ReleaseId",
                table: "Sprints");
        }
    }
}
