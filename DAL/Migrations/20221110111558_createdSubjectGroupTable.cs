using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class createdSubjectGroupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SubjectKollekvumStudents_StudentId",
                table: "SubjectKollekvumStudents");

            migrationBuilder.CreateTable(
                name: "SubjectGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectGroups_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectKollekvumStudents_StudentId",
                table: "SubjectKollekvumStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectGroups_GroupId",
                table: "SubjectGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectGroups_SubjectId",
                table: "SubjectGroups",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectGroups");

            migrationBuilder.DropIndex(
                name: "IX_SubjectKollekvumStudents_StudentId",
                table: "SubjectKollekvumStudents");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectKollekvumStudents_StudentId",
                table: "SubjectKollekvumStudents",
                column: "StudentId",
                unique: true);
        }
    }
}
