using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class addedKollekvum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Division",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KollekvumId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SerbestIsId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Kollekvums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstKollekvum = table.Column<int>(type: "int", nullable: false),
                    SecondKollekvum = table.Column<int>(type: "int", nullable: false),
                    ThirdKollekvum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kollekvums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SerbestIss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstGrade = table.Column<int>(type: "int", nullable: false),
                    SecondGrade = table.Column<int>(type: "int", nullable: false),
                    ThirdGrade = table.Column<int>(type: "int", nullable: false),
                    FourthGrade = table.Column<int>(type: "int", nullable: false),
                    FiveGrade = table.Column<int>(type: "int", nullable: false),
                    SixGrade = table.Column<int>(type: "int", nullable: false),
                    SevenGrade = table.Column<int>(type: "int", nullable: false),
                    EightGrade = table.Column<int>(type: "int", nullable: false),
                    NineGrade = table.Column<int>(type: "int", nullable: false),
                    TenGrade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerbestIss", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_FacultyId",
                table: "Students",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_KollekvumId",
                table: "Students",
                column: "KollekvumId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SerbestIsId",
                table: "Students",
                column: "SerbestIsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Faculties_FacultyId",
                table: "Students",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Kollekvums_KollekvumId",
                table: "Students",
                column: "KollekvumId",
                principalTable: "Kollekvums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_SerbestIss_SerbestIsId",
                table: "Students",
                column: "SerbestIsId",
                principalTable: "SerbestIss",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Faculties_FacultyId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Kollekvums_KollekvumId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_SerbestIss_SerbestIsId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Kollekvums");

            migrationBuilder.DropTable(
                name: "SerbestIss");

            migrationBuilder.DropIndex(
                name: "IX_Students_FacultyId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_KollekvumId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_SerbestIsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Division",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "KollekvumId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SerbestIsId",
                table: "Students");
        }
    }
}
