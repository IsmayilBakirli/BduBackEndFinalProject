using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class updateGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SpecialtyId",
                table: "Groups",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Specialties_SpecialtyId",
                table: "Groups",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Specialties_SpecialtyId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_SpecialtyId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Groups");
        }
    }
}
