using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsTracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credit_Students_StudentId",
                table: "Credit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Credit",
                table: "Credit");

            migrationBuilder.RenameTable(
                name: "Credit",
                newName: "Credits");

            migrationBuilder.RenameIndex(
                name: "IX_Credit_StudentId",
                table: "Credits",
                newName: "IX_Credits_StudentId");

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "Majors",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Credits",
                table: "Credits",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Majors_FacultyId",
                table: "Majors",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_Students_StudentId",
                table: "Credits",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Majors_Faculties_FacultyId",
                table: "Majors",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Students_StudentId",
                table: "Credits");

            migrationBuilder.DropForeignKey(
                name: "FK_Majors_Faculties_FacultyId",
                table: "Majors");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Majors_FacultyId",
                table: "Majors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Credits",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Majors");

            migrationBuilder.RenameTable(
                name: "Credits",
                newName: "Credit");

            migrationBuilder.RenameIndex(
                name: "IX_Credits_StudentId",
                table: "Credit",
                newName: "IX_Credit_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Credit",
                table: "Credit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Credit_Students_StudentId",
                table: "Credit",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
