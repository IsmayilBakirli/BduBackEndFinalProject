using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class updatedDekan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Dekans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "Dekans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Dekans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Dekans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dekans_FacultyId",
                table: "Dekans",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dekans_Faculties_FacultyId",
                table: "Dekans",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dekans_Faculties_FacultyId",
                table: "Dekans");

            migrationBuilder.DropIndex(
                name: "IX_Dekans_FacultyId",
                table: "Dekans");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Dekans");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Dekans");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Dekans");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Dekans");
        }
    }
}
