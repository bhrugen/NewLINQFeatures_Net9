using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewLINQFeatures.Data.Migrations
{
    /// <inheritdoc />
    public partial class inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentScores_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, "Male", "Ben" },
                    { 2, "Male", "Bill" },
                    { 3, "Female", "Lana" }
                });

            migrationBuilder.InsertData(
                table: "StudentScores",
                columns: new[] { "Id", "Score", "StudentId", "SubjectName" },
                values: new object[,]
                {
                    { 1, 99, 1, "Math" },
                    { 2, 85, 1, "Science" },
                    { 3, 85, 1, "Geography" },
                    { 4, 65, 2, "Math" },
                    { 5, 59, 2, "Science" },
                    { 6, 80, 2, "Geography" },
                    { 7, 50, 3, "Math" },
                    { 8, 70, 3, "Science" },
                    { 9, 90, 3, "Geography" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentScores_StudentId",
                table: "StudentScores",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentScores");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
