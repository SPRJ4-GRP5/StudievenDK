using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudievenDK.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Birthday = table.Column<string>(nullable: true),
                    FieldOfStudy = table.Column<string>(nullable: true),
                    Faculty = table.Column<string>(nullable: true),
                    Term = table.Column<int>(nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    FacultyName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.FacultyName);
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
                name: "User",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseName = table.Column<string>(nullable: false),
                    FacultyName_fk = table.Column<string>(nullable: true),
                    TermYear_fk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseName);
                    table.ForeignKey(
                        name: "FK_Course_Faculties_FacultyName_fk",
                        column: x => x.FacultyName_fk,
                        principalTable: "Faculties",
                        principalColumn: "FacultyName",
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
                    Deadline = table.Column<DateTime>(nullable: false),
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
                        name: "FK_Cases_User_UserHelper_fk",
                        column: x => x.UserHelper_fk,
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cases_User_UserSeeker_fk",
                        column: x => x.UserSeeker_fk,
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseProgrammes_ST",
                columns: table => new
                {
                    CourseName_fk = table.Column<string>(nullable: false),
                    ProgrammeName_fk = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProgrammes_ST", x => new { x.CourseName_fk, x.ProgrammeName_fk });
                    table.ForeignKey(
                        name: "FK_CourseProgrammes_ST_Course_CourseName_fk",
                        column: x => x.CourseName_fk,
                        principalTable: "Course",
                        principalColumn: "CourseName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseProgrammes_ST_Programmes_ProgrammeName_fk",
                        column: x => x.ProgrammeName_fk,
                        principalTable: "Programmes",
                        principalColumn: "ProgrammeName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                column: "FacultyName",
                values: new object[]
                {
                    "Natural Sciences",
                    "Technical Sciences",
                    "Health",
                    "Aarhus BSS",
                    "Arts"
                });

            migrationBuilder.InsertData(
                table: "Programmes",
                column: "ProgrammeName",
                values: new object[]
                {
                    "IKT",
                    "E",
                    "ST",
                    "EE",
                    "Datalogi",
                    "Medievidenskab"
                });

            migrationBuilder.InsertData(
                table: "Terms",
                column: "TermYear",
                values: new object[]
                {
                    7,
                    6,
                    5,
                    2,
                    3,
                    1,
                    4
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Email", "ImageName", "Password" },
                values: new object[,]
                {
                    { "Randi@Studieven.dk", null, "admin" },
                    { "Alexander@Studieven.dk", null, "admin" },
                    { "Thanh@Studieven.dk", null, "admin" },
                    { "Mads@Studieven.dk", null, "admin" },
                    { "Trang@Studieven.dk", null, "admin" },
                    { "Nikolaj@Studieven.dk", null, "admin" },
                    { "Jonas@Studieven.dk", null, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseName", "FacultyName_fk", "TermYear_fk" },
                values: new object[,]
                {
                    { "ISU", "Technical Sciences", 3 },
                    { "DOA", "Technical Sciences", 3 },
                    { "SWT", "Technical Sciences", 3 },
                    { "DSB", "Technical Sciences", 3 },
                    { "GUI", "Technical Sciences", 4 },
                    { "DAB", "Technical Sciences", 4 }
                });

            migrationBuilder.InsertData(
                table: "Cases",
                columns: new[] { "CaseId", "CourseName_fk", "Deadline", "PictureName", "Subject", "Text", "UserHelper_fk", "UserSeeker_fk" },
                values: new object[,]
                {
                    { 3, "ISU", new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Local), null, "threads", "hvordan opretter man en traad?", "Trang@Studieven.dk", "Jonas@Studieven.dk" },
                    { 1, "GUI", new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Local), null, "Hjaelp?", "Jeg har brug for hjaelp", "Alexander@Studieven.dk", "Thanh@Studieven.dk" },
                    { 4, "GUI", new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Local), null, "user interface", "observer pattern - forklar lige det paa en knap", "Randi@Studieven.dk", "Nikolaj@Studieven.dk" },
                    { 5, "GUI", new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Local), null, "fare paa knap", "hvordan laver jeg farven gul paa en knap", "Nikolaj@Studieven.dk", "Mads@Studieven.dk" },
                    { 2, "DAB", new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Local), null, "EF core", "Jeg skal bruge hjaelp til DAB", "Thanh@Studieven.dk", "Alexander@Studieven.dk" }
                });

            migrationBuilder.InsertData(
                table: "CourseProgrammes_ST",
                columns: new[] { "CourseName_fk", "ProgrammeName_fk" },
                values: new object[,]
                {
                    { "ISU", "IKT" },
                    { "SWT", "ST" },
                    { "SWT", "IKT" },
                    { "DSB", "E" },
                    { "DSB", "IKT" },
                    { "GUI", "IKT" },
                    { "DAB", "IKT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_Course_FacultyName_fk",
                table: "Course",
                column: "FacultyName_fk");

            migrationBuilder.CreateIndex(
                name: "IX_Course_TermYear_fk",
                table: "Course",
                column: "TermYear_fk");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProgrammes_ST_ProgrammeName_fk",
                table: "CourseProgrammes_ST",
                column: "ProgrammeName_fk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "CourseProgrammes_ST");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "User");

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
