using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class CreaeteIssueDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IssueTypeId",
                table: "Issues",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "IssueDetails",
                columns: table => new
                {
                    IssueDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachment = table.Column<string>(nullable: true),
                    Reporter = table.Column<int>(nullable: false),
                    Enviroment = table.Column<string>(nullable: true),
                    Browser = table.Column<string>(nullable: true),
                    AcceptanceCriteria = table.Column<string>(nullable: true),
                    StoryPoints = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Epic = table.Column<int>(nullable: false),
                    UAT = table.Column<int>(nullable: false),
                    MyProperty = table.Column<bool>(nullable: false),
                    TimeTracking = table.Column<string>(nullable: true),
                    IssueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueDetails", x => x.IssueDetailsId);
                    table.ForeignKey(
                        name: "FK_IssueDetails_Issues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issues",
                        principalColumn: "IssueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_IssueTypeId",
                table: "Issues",
                column: "IssueTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueDetails_IssueId",
                table: "IssueDetails",
                column: "IssueId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_IssueType_IssueTypeId",
                table: "Issues",
                column: "IssueTypeId",
                principalTable: "IssueType",
                principalColumn: "IssueTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_IssueType_IssueTypeId",
                table: "Issues");

            migrationBuilder.DropTable(
                name: "IssueDetails");

            migrationBuilder.DropIndex(
                name: "IX_Issues_IssueTypeId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "IssueTypeId",
                table: "Issues");
        }
    }
}
