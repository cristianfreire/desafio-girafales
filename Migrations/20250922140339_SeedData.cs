using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace desafio_girafales.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bloco A" },
                    { 2, "Bloco B" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ciência da Computação" },
                    { 2, "Matemática" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Code", "Name", "SubjectId" },
                values: new object[,]
                {
                    { 1, 0, "", "CS101" },
                    { 2, 0, "", "CS201" },
                    { 3, 0, "", "MAT101" }
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Professor Assistente" },
                    { 2, "Professor Associado" },
                    { 3, "Professor Titular" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Code", "Semester", "SubjectId", "Year" },
                values: new object[,]
                {
                    { 1, "CS101-1", 1, 1, 2025 },
                    { 2, "CS201-1", 2, 2, 2025 }
                });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "DepartmentId", "TitleId" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 2, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BuildingId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "SubjectPrerequisites",
                columns: new[] { "Id", "PrerequisiteId", "SubjectId" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "ClassSchedules",
                columns: new[] { "Id", "ClassId", "DayOfWeek", "EndTime", "RoomId", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, 1, new TimeSpan(0, 10, 0, 0, 0), 1, new TimeSpan(0, 8, 0, 0, 0) },
                    { 2, 2, 3, new TimeSpan(0, 12, 0, 0, 0), 2, new TimeSpan(0, 10, 0, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassSchedules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClassSchedules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubjectPrerequisites",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
