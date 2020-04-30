using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudievenDK.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Cases",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Cases",
                keyColumn: "CaseId",
                keyValue: 1,
                column: "Deadline",
                value: new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cases",
                keyColumn: "CaseId",
                keyValue: 2,
                column: "Deadline",
                value: new DateTime(2020, 4, 25, 23, 13, 29, 28, DateTimeKind.Local).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "Cases",
                keyColumn: "CaseId",
                keyValue: 3,
                column: "Deadline",
                value: new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cases",
                keyColumn: "CaseId",
                keyValue: 4,
                column: "Deadline",
                value: new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cases",
                keyColumn: "CaseId",
                keyValue: 5,
                column: "Deadline",
                value: new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Cases");
        }
    }
}
