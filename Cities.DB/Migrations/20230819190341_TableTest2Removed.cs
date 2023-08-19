using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cities.DB.Migrations
{
    /// <inheritdoc />
    public partial class TableTest2Removed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Tests1_Test1Id",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests1_Tests_TestId",
                table: "Tests1");

            migrationBuilder.DropTable(
                name: "Tests2");

            migrationBuilder.DropIndex(
                name: "IX_Tests1_TestId",
                table: "Tests1");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Tests1");

            migrationBuilder.AlterColumn<long>(
                name: "Test1Id",
                table: "Tests",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Tests1_Test1Id",
                table: "Tests",
                column: "Test1Id",
                principalTable: "Tests1",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Tests1_Test1Id",
                table: "Tests");

            migrationBuilder.AddColumn<long>(
                name: "TestId",
                table: "Tests1",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "Test1Id",
                table: "Tests",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Tests2",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<long>(type: "bigint", nullable: false),
                    TestData = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests2_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tests1_TestId",
                table: "Tests1",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests2_TestId",
                table: "Tests2",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Tests1_Test1Id",
                table: "Tests",
                column: "Test1Id",
                principalTable: "Tests1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests1_Tests_TestId",
                table: "Tests1",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
