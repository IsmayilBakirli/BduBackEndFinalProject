using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class studentRelationsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Kollekvums_KollekvumId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_SerbestIss_SerbestIsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_KollekvumId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_SerbestIsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "KollekvumId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SerbestIsId",
                table: "Students");

            migrationBuilder.CreateTable(
                name: "StudentSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectKollekvumStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    KollekvumId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectKollekvumStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectKollekvumStudents_Kollekvums_KollekvumId",
                        column: x => x.KollekvumId,
                        principalTable: "Kollekvums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectKollekvumStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectKollekvumStudents_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectSerbesIsStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    SerbestIsId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectSerbesIsStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectSerbesIsStudents_SerbestIss_SerbestIsId",
                        column: x => x.SerbestIsId,
                        principalTable: "SerbestIss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectSerbesIsStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectSerbesIsStudents_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_StudentId",
                table: "StudentSubjects",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_SubjectId",
                table: "StudentSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectKollekvumStudents_KollekvumId",
                table: "SubjectKollekvumStudents",
                column: "KollekvumId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectKollekvumStudents_StudentId",
                table: "SubjectKollekvumStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectKollekvumStudents_SubjectId",
                table: "SubjectKollekvumStudents",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectSerbesIsStudents_SerbestIsId",
                table: "SubjectSerbesIsStudents",
                column: "SerbestIsId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectSerbesIsStudents_StudentId",
                table: "SubjectSerbesIsStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectSerbesIsStudents_SubjectId",
                table: "SubjectSerbesIsStudents",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubjects");

            migrationBuilder.DropTable(
                name: "SubjectKollekvumStudents");

            migrationBuilder.DropTable(
                name: "SubjectSerbesIsStudents");

            migrationBuilder.AddColumn<int>(
                name: "KollekvumId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SerbestIsId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_KollekvumId",
                table: "Students",
                column: "KollekvumId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SerbestIsId",
                table: "Students",
                column: "SerbestIsId");

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
    }
}
