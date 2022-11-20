using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class studenttablenullableupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Kollekvums_KollekvumId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_SerbestIss_SerbestIsId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "SerbestIsId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KollekvumId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                name: "FK_Students_Kollekvums_KollekvumId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_SerbestIss_SerbestIsId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "SerbestIsId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KollekvumId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Kollekvums_KollekvumId",
                table: "Students",
                column: "KollekvumId",
                principalTable: "Kollekvums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_SerbestIss_SerbestIsId",
                table: "Students",
                column: "SerbestIsId",
                principalTable: "SerbestIss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
