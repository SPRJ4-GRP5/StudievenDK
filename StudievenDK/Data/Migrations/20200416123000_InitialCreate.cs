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
                    FacultyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyName = table.Column<string>(nullable: true)
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
                    TermYear = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
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
                    FacultyName_fk = table.Column<string>(nullable: true),
                    TermYear_fk = table.Column<int>(nullable: false),
                    FacultiesFacultyId = table.Column<int>(nullable: true)
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
                        name: "FK_Course_Terms_TermYear_fk",
                        column: x => x.TermYear_fk,
                        principalTable: "Terms",
                        principalColumn: "TermYear",
                        onDelete: ReferentialAction.Cascade);
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
                    CourseName_fk = table.Column<string>(nullable: true),
                    PictureName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.CaseId);
                    table.ForeignKey(
                        name: "FK_Cases_Course_CourseName_fk",
                        column: x => x.CourseName_fk,
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
                    CourseName_fk = table.Column<string>(nullable: false),
                    ProgrammeName_fk = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProgramme", x => new { x.CourseName_fk, x.ProgrammeName_fk });
                    table.ForeignKey(
                        name: "FK_CourseProgramme_Course_CourseName_fk",
                        column: x => x.CourseName_fk,
                        principalTable: "Course",
                        principalColumn: "CourseName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseProgramme_Programmes_ProgrammeName_fk",
                        column: x => x.ProgrammeName_fk,
                        principalTable: "Programmes",
                        principalColumn: "ProgrammeName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "FacultyId", "FacultyName" },
                values: new object[,]
                {
                    { 1, "Natural Sciences" },
                    { 2, "Technical Sciences" },
                    { 3, "Health" },
                    { 4, "Aarhus BSS" },
                    { 5, "Arts" }
                });

            migrationBuilder.InsertData(
                table: "Programmes",
                column: "ProgrammeName",
                value: "IKT");

            migrationBuilder.InsertData(
                table: "Terms",
                column: "TermYear",
                values: new object[]
                {
                    7,
                    6,
                    5,
                    4,
                    3,
                    2,
                    1
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "ImageName", "Password" },
                values: new object[,]
                {
                    { "Alexander@Studieven.dk", null, "admin" },
                    { "Thanh@Studieven.dk", null, "admin" },
                    { "Mads@Studieven.dk", null, "admin" },
                    { "Trang@Studieven.dk", null, "admin" },
                    { "Nikolaj@Studieven.dk", null, "admin" },
                    { "Randi@Studieven.dk", null, "admin" },
                    { "Jonas@Studieven.dk", null, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseName", "FacultiesFacultyId", "FacultyName_fk", "TermYear_fk" },
                values: new object[,]
                {
                    { "ISU", null, "Technical Sciences", 3 },
                    { "DOA", null, "Technical Sciences", 3 },
                    { "GUI", null, "Technical Sciences", 4 },
                    { "DAB", null, "Technical Sciences", 4 }
                });

            migrationBuilder.InsertData(
                table: "Cases",
                columns: new[] { "CaseId", "CourseName_fk", "PictureName", "Subject", "Text", "UserHelper_fk", "UserSeeker_fk" },
                values: new object[] { 1, "GUI", null, "Hjælp?", "Jeg har brug for hjælp", "Alexander@Studieven.dk", "Thanh@Studieven.dk" });

            migrationBuilder.InsertData(
                table: "CourseProgramme",
                columns: new[] { "CourseName_fk", "ProgrammeName_fk" },
                values: new object[] { "GUI", "IKT" });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CourseName_fk",
                table: "Cases",
                column: "CourseName_fk");

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
                name: "IX_Course_TermYear_fk",
                table: "Course",
                column: "TermYear_fk");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProgramme_ProgrammeName_fk",
                table: "CourseProgramme",
                column: "ProgrammeName_fk");
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
