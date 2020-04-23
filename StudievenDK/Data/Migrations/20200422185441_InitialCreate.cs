using Microsoft.EntityFrameworkCore.Migrations;

namespace StudievenDK.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    FacultyId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.FacultyId);
                });

            migrationBuilder.CreateTable(
                name: "Programmes",
                columns: table => new
                {
                    ProgrammeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programmes", x => x.ProgrammeName);
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    TermYear = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.TermYear);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseName = table.Column<string>(nullable: false),
                    Faculty = table.Column<string>(nullable: true),
                    TermYear = table.Column<string>(nullable: true),
                    FacultiesFacultyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseName);
                    table.ForeignKey(
                        name: "FK_Course_Faculties_FacultiesFacultyId",
                        column: x => x.FacultiesFacultyId,
                        principalTable: "Faculties",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Course_Terms_TermYear",
                        column: x => x.TermYear,
                        principalTable: "Terms",
                        principalColumn: "TermYear",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    CaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    UserHelper_fk = table.Column<string>(nullable: true),
                    UserSeeker_fk = table.Column<string>(nullable: true),
                    CourseName = table.Column<string>(nullable: true),
                    PictureName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.CaseId);
                    table.ForeignKey(
                        name: "FK_Cases_Course_CourseName",
                        column: x => x.CourseName,
                        principalTable: "Course",
                        principalColumn: "CourseName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cases_Users_UserHelper_fk",
                        column: x => x.UserHelper_fk,
                        principalTable: "Users",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cases_Users_UserSeeker_fk",
                        column: x => x.UserSeeker_fk,
                        principalTable: "Users",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseProgramme",
                columns: table => new
                {
                    CourseName = table.Column<string>(nullable: false),
                    ProgrammeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProgramme", x => new { x.CourseName, x.ProgrammeName });
                    table.ForeignKey(
                        name: "FK_CourseProgramme_Course_CourseName",
                        column: x => x.CourseName,
                        principalTable: "Course",
                        principalColumn: "CourseName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseProgramme_Programmes_ProgrammeName",
                        column: x => x.ProgrammeName,
                        principalTable: "Programmes",
                        principalColumn: "ProgrammeName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CourseName",
                table: "Cases",
                column: "CourseName");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_UserHelper_fk",
                table: "Cases",
                column: "UserHelper_fk");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_UserSeeker_fk",
                table: "Cases",
                column: "UserSeeker_fk");

            migrationBuilder.CreateIndex(
                name: "IX_Course_FacultiesFacultyId",
                table: "Course",
                column: "FacultiesFacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_TermYear",
                table: "Course",
                column: "TermYear");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProgramme_ProgrammeName",
                table: "CourseProgramme",
                column: "ProgrammeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "CourseProgramme");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Programmes");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Terms");
        }
    }
}
