using Microsoft.EntityFrameworkCore.Migrations;

namespace StudievenDK.Data.Migrations
{
    public partial class alexander : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Course_CourseName_fk",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Terms_TermYear_fk",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseProgramme_Course_CourseName_fk",
                table: "CourseProgramme");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseProgramme_Programmes_ProgrammeName_fk",
                table: "CourseProgramme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Terms",
                table: "Terms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Programmes",
                table: "Programmes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "TermYear_fk",
                table: "Terms");

            migrationBuilder.DropColumn(
                name: "ProgrammeName_fk",
                table: "Programmes");

            migrationBuilder.DropColumn(
                name: "CourseName_fk",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "FacultyName",
                table: "Course");

            migrationBuilder.AddColumn<int>(
                name: "TermYear",
                table: "Terms",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ProgrammeName",
                table: "Programmes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "FacultyId",
                table: "Faculties",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "FacultyName",
                table: "Faculties",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TermYear_fk",
                table: "Course",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FacultiesFacultyId",
                table: "Course",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "Course",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacultyName_fk",
                table: "Course",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Terms",
                table: "Terms",
                column: "TermYear");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programmes",
                table: "Programmes",
                column: "ProgrammeName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "CourseName");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Course_CourseName_fk",
                table: "Cases",
                column: "CourseName_fk",
                principalTable: "Course",
                principalColumn: "CourseName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Terms_TermYear_fk",
                table: "Course",
                column: "TermYear_fk",
                principalTable: "Terms",
                principalColumn: "TermYear",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseProgramme_Course_CourseName_fk",
                table: "CourseProgramme",
                column: "CourseName_fk",
                principalTable: "Course",
                principalColumn: "CourseName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseProgramme_Programmes_ProgrammeName_fk",
                table: "CourseProgramme",
                column: "ProgrammeName_fk",
                principalTable: "Programmes",
                principalColumn: "ProgrammeName",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Course_CourseName_fk",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Terms_TermYear_fk",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseProgramme_Course_CourseName_fk",
                table: "CourseProgramme");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseProgramme_Programmes_ProgrammeName_fk",
                table: "CourseProgramme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Terms",
                table: "Terms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Programmes",
                table: "Programmes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DeleteData(
                table: "Cases",
                keyColumn: "CaseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseName",
                keyValue: "DAB");

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseName",
                keyValue: "DOA");

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseName",
                keyValue: "ISU");

            migrationBuilder.DeleteData(
                table: "CourseProgramme",
                keyColumns: new[] { "CourseName_fk", "ProgrammeName_fk" },
                keyValues: new object[] { "GUI", "IKT" });

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "TermYear",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "TermYear",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "TermYear",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "TermYear",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "TermYear",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "Jonas@Studieven.dk");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "Mads@Studieven.dk");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "Nikolaj@Studieven.dk");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "Randi@Studieven.dk");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "Trang@Studieven.dk");

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseName",
                keyValue: "GUI");

            migrationBuilder.DeleteData(
                table: "Programmes",
                keyColumn: "ProgrammeName",
                keyValue: "IKT");

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "TermYear",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "Alexander@Studieven.dk");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "Thanh@Studieven.dk");

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "TermYear",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "TermYear",
                table: "Terms");

            migrationBuilder.DropColumn(
                name: "ProgrammeName",
                table: "Programmes");

            migrationBuilder.DropColumn(
                name: "FacultyName",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "FacultyName_fk",
                table: "Course");

            migrationBuilder.AddColumn<string>(
                name: "TermYear_fk",
                table: "Terms",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProgrammeName_fk",
                table: "Programmes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "FacultyId",
                table: "Faculties",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "TermYear_fk",
                table: "Course",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "FacultiesFacultyId",
                table: "Course",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseName_fk",
                table: "Course",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacultyName",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Terms",
                table: "Terms",
                column: "TermYear_fk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programmes",
                table: "Programmes",
                column: "ProgrammeName_fk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "CourseName_fk");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Course_CourseName_fk",
                table: "Cases",
                column: "CourseName_fk",
                principalTable: "Course",
                principalColumn: "CourseName_fk",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Terms_TermYear_fk",
                table: "Course",
                column: "TermYear_fk",
                principalTable: "Terms",
                principalColumn: "TermYear_fk",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseProgramme_Course_CourseName_fk",
                table: "CourseProgramme",
                column: "CourseName_fk",
                principalTable: "Course",
                principalColumn: "CourseName_fk",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseProgramme_Programmes_ProgrammeName_fk",
                table: "CourseProgramme",
                column: "ProgrammeName_fk",
                principalTable: "Programmes",
                principalColumn: "ProgrammeName_fk",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
