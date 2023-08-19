using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cities.DB.Migrations
{
    /// <inheritdoc />
    public partial class ReferencesRecheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tests_Test1Id",
                table: "Tests");

            migrationBuilder.AddColumn<long>(
                name: "TestId",
                table: "Tests1",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Tests1_TestId",
                table: "Tests1",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_Test1Id",
                table: "Tests",
                column: "Test1Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests1_Tests_TestId",
                table: "Tests1",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests1_Tests_TestId",
                table: "Tests1");

            migrationBuilder.DropIndex(
                name: "IX_Tests1_TestId",
                table: "Tests1");

            migrationBuilder.DropIndex(
                name: "IX_Tests_Test1Id",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Tests1");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_Test1Id",
                table: "Tests",
                column: "Test1Id",
                unique: true);
        }
    }
}
