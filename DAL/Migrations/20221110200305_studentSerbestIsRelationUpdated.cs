using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class studentSerbestIsRelationUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_SerbestIss_SerbestIsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_SerbestIsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SerbestIsId",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SerbestIsId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_SerbestIsId",
                table: "Students",
                column: "SerbestIsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_SerbestIss_SerbestIsId",
                table: "Students",
                column: "SerbestIsId",
                principalTable: "SerbestIss",
                principalColumn: "Id");
        }
    }
}
