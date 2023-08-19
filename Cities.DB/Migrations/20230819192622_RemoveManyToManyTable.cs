using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cities.DB.Migrations
{
    /// <inheritdoc />
    public partial class RemoveManyToManyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestTestMany");

            migrationBuilder.DropTable(
                name: "TestsManies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestsManies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestsManies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestTestMany",
                columns: table => new
                {
                    TestManiesId = table.Column<long>(type: "bigint", nullable: false),
                    TestsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTestMany", x => new { x.TestManiesId, x.TestsId });
                    table.ForeignKey(
                        name: "FK_TestTestMany_TestsManies_TestManiesId",
                        column: x => x.TestManiesId,
                        principalTable: "TestsManies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestTestMany_Tests_TestsId",
                        column: x => x.TestsId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestTestMany_TestsId",
                table: "TestTestMany",
                column: "TestsId");
        }
    }
}
