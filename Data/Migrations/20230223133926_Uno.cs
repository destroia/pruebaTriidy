using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Uno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PhoneCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Contries_ContryId",
                        column: x => x.ContryId,
                        principalTable: "Contries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ContryId",
                table: "Cities",
                column: "ContryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Contries");
        }
    }
}
