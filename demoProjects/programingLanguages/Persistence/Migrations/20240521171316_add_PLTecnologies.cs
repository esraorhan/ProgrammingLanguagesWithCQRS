﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class add_PLTecnologies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgrammingLanguageTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgrammingLanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguageTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgrammingLanguageTechnologies_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "CreatedTime", "Name", "Version" },
                values: new object[] { 1, new DateTime(2024, 5, 21, 20, 13, 16, 698, DateTimeKind.Local).AddTicks(271), "C#", "7.0" });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "CreatedTime", "Name", "Version" },
                values: new object[] { 2, new DateTime(2024, 5, 21, 20, 13, 16, 698, DateTimeKind.Local).AddTicks(283), "Ruby", "4.0" });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguageTechnologies",
                columns: new[] { "Id", "Description", "Name", "ProgrammingLanguageId" },
                values: new object[] { 1, "Örnek sürüm", "MVC", 1 });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguageTechnologies",
                columns: new[] { "Id", "Description", "Name", "ProgrammingLanguageId" },
                values: new object[] { 2, "Örnek sürüm", "Core", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingLanguageTechnologies_ProgrammingLanguageId",
                table: "ProgrammingLanguageTechnologies",
                column: "ProgrammingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammingLanguageTechnologies");

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
