using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsTracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Credits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Credits_TeacherId",
                table: "Credits",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_Teachers_TeacherId",
                table: "Credits",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Teachers_TeacherId",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_Credits_TeacherId",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Credits");
        }
    }
}
