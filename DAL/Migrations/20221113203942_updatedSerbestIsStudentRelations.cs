using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class updatedSerbestIsStudentRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectSerbesIsStudents_Students_StudentId",
                table: "SubjectSerbesIsStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectSerbesIsStudents_Subjects_SubjectId",
                table: "SubjectSerbesIsStudents");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "SubjectSerbesIsStudents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "SubjectSerbesIsStudents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectSerbesIsStudents_Students_StudentId",
                table: "SubjectSerbesIsStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectSerbesIsStudents_Subjects_SubjectId",
                table: "SubjectSerbesIsStudents",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectSerbesIsStudents_Students_StudentId",
                table: "SubjectSerbesIsStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectSerbesIsStudents_Subjects_SubjectId",
                table: "SubjectSerbesIsStudents");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "SubjectSerbesIsStudents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "SubjectSerbesIsStudents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectSerbesIsStudents_Students_StudentId",
                table: "SubjectSerbesIsStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectSerbesIsStudents_Subjects_SubjectId",
                table: "SubjectSerbesIsStudents",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
