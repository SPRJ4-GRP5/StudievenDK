using Microsoft.EntityFrameworkCore.Migrations;

namespace StudievenDK.Migrations
{
    public partial class changced_user_to_applicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_User_UserHelper_fk",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Term_TermYear_fk",
                table: "Course");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_User_TempId1",
                table: "User");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_User_TempId2",
                table: "User");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Term_TempId",
                table: "Term");

            migrationBuilder.DropColumn(
                name: "TempId1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TempId",
                table: "Term");

            migrationBuilder.RenameTable(
                name: "Term",
                newName: "Terms");

            migrationBuilder.RenameColumn(
                name: "TempId2",
                table: "User",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Birthday",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetUsers",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Faculty",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FieldOfStudy",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Term",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TermYear",
                table: "Terms",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Terms",
                table: "Terms",
                column: "TermYear");

            migrationBuilder.InsertData(
                table: "Terms",
                column: "TermYear",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7
                });

            migrationBuilder.InsertData(
                table: "User",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_User_UserHelper_fk",
                table: "Cases",
                column: "UserHelper_fk",
                principalTable: "User",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Terms_TermYear_fk",
                table: "Course",
                column: "TermYear_fk",
                principalTable: "Terms",
                principalColumn: "TermYear",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_User_UserHelper_fk",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Terms_TermYear_fk",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Terms",
                table: "Terms");

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
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "TermYear",
                keyValue: 4);

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
                table: "User",
                keyColumn: "Email",
                keyValue: "Randi@Studieven.dk");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Email",
                keyValue: "Trang@Studieven.dk");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Email",
                keyValue: "Alexander@Studieven.dk");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Email",
                keyValue: "Jonas@Studieven.dk");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Email",
                keyValue: "Mads@Studieven.dk");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Email",
                keyValue: "Nikolaj@Studieven.dk");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Email",
                keyValue: "Thanh@Studieven.dk");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Faculty",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FieldOfStudy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Term",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TermYear",
                table: "Terms");

            migrationBuilder.RenameTable(
                name: "Terms",
                newName: "Term");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "User",
                newName: "TempId2");

            migrationBuilder.AddColumn<string>(
                name: "TempId1",
                table: "User",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TempId",
                table: "Term",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_User_TempId1",
                table: "User",
                column: "TempId1");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_User_TempId2",
                table: "User",
                column: "TempId2");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Term_TempId",
                table: "Term",
                column: "TempId");

            migrationBuilder.UpdateData(
                table: "Cases",
                keyColumn: "CaseId",
                keyValue: 1,
                column: "UserSeeker_fk",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cases",
                keyColumn: "CaseId",
                keyValue: 2,
                column: "UserSeeker_fk",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cases",
                keyColumn: "CaseId",
                keyValue: 3,
                column: "UserSeeker_fk",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cases",
                keyColumn: "CaseId",
                keyValue: 4,
                column: "UserSeeker_fk",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cases",
                keyColumn: "CaseId",
                keyValue: 5,
                column: "UserSeeker_fk",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_User_UserHelper_fk",
                table: "Cases",
                column: "UserHelper_fk",
                principalTable: "User",
                principalColumn: "TempId1",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Term_TermYear_fk",
                table: "Course",
                column: "TermYear_fk",
                principalTable: "Term",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
