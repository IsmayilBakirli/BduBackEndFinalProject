using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class updatedKollekvumSubjectStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectKollekvumStudents_Kollekvums_KollekvumId",
                table: "SubjectKollekvumStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectKollekvumStudents_Subjects_SubjectId",
                table: "SubjectKollekvumStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectSerbesIsStudents_SerbestIss_SerbestIsId",
                table: "SubjectSerbesIsStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectSerbesIsStudents_Students_StudentId",
                table: "SubjectSerbesIsStudents");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "SubjectSerbesIsStudents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SerbestIsId",
                table: "SubjectSerbesIsStudents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "SubjectKollekvumStudents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KollekvumId",
                table: "SubjectKollekvumStudents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectKollekvumStudents_Kollekvums_KollekvumId",
                table: "SubjectKollekvumStudents",
                column: "KollekvumId",
                principalTable: "Kollekvums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectKollekvumStudents_Subjects_SubjectId",
                table: "SubjectKollekvumStudents",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectSerbesIsStudents_SerbestIss_SerbestIsId",
                table: "SubjectSerbesIsStudents",
                column: "SerbestIsId",
                principalTable: "SerbestIss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectSerbesIsStudents_Students_StudentId",
                table: "SubjectSerbesIsStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectKollekvumStudents_Kollekvums_KollekvumId",
                table: "SubjectKollekvumStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectKollekvumStudents_Subjects_SubjectId",
                table: "SubjectKollekvumStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectSerbesIsStudents_SerbestIss_SerbestIsId",
                table: "SubjectSerbesIsStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectSerbesIsStudents_Students_StudentId",
                table: "SubjectSerbesIsStudents");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "SubjectSerbesIsStudents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SerbestIsId",
                table: "SubjectSerbesIsStudents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "SubjectKollekvumStudents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KollekvumId",
                table: "SubjectKollekvumStudents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectKollekvumStudents_Kollekvums_KollekvumId",
                table: "SubjectKollekvumStudents",
                column: "KollekvumId",
                principalTable: "Kollekvums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectKollekvumStudents_Subjects_SubjectId",
                table: "SubjectKollekvumStudents",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectSerbesIsStudents_SerbestIss_SerbestIsId",
                table: "SubjectSerbesIsStudents",
                column: "SerbestIsId",
                principalTable: "SerbestIss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectSerbesIsStudents_Students_StudentId",
                table: "SubjectSerbesIsStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
