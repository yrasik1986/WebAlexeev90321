using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAlexeev90321.DAL.Migrations
{
    public partial class EntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RadioComponentGroups",
                columns: table => new
                {
                    RadioComponentGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadioComponentGroups", x => x.RadioComponentGroupId);
                });

            migrationBuilder.CreateTable(
                name: "RadioComponents",
                columns: table => new
                {
                    RadioComponentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RadioComponentName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    RadioComponentGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadioComponents", x => x.RadioComponentId);
                    table.ForeignKey(
                        name: "FK_RadioComponents_RadioComponentGroups_RadioComponentGroupId",
                        column: x => x.RadioComponentGroupId,
                        principalTable: "RadioComponentGroups",
                        principalColumn: "RadioComponentGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RadioComponents_RadioComponentGroupId",
                table: "RadioComponents",
                column: "RadioComponentGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RadioComponents");

            migrationBuilder.DropTable(
                name: "RadioComponentGroups");
        }
    }
}
