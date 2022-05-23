using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGBenefic.API.Migrations
{
    public partial class AddModelUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Beneficities",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataConcessaoBeneficio",
                value: new DateTime(2022, 5, 21, 20, 41, 30, 760, DateTimeKind.Local).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "Beneficities",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataConcessaoBeneficio",
                value: new DateTime(2022, 5, 22, 20, 41, 30, 762, DateTimeKind.Local).AddTicks(6669));

            migrationBuilder.UpdateData(
                table: "Beneficities",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataConcessaoBeneficio",
                value: new DateTime(2022, 5, 20, 20, 41, 30, 762, DateTimeKind.Local).AddTicks(6707));

            migrationBuilder.UpdateData(
                table: "Beneficities",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataConcessaoBeneficio",
                value: new DateTime(2022, 5, 19, 20, 41, 30, 762, DateTimeKind.Local).AddTicks(6715));

            migrationBuilder.UpdateData(
                table: "Beneficities",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataConcessaoBeneficio",
                value: new DateTime(2022, 5, 17, 20, 41, 30, 762, DateTimeKind.Local).AddTicks(6718));

            migrationBuilder.UpdateData(
                table: "Beneficities",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataConcessaoBeneficio",
                value: new DateTime(2022, 5, 21, 20, 41, 30, 762, DateTimeKind.Local).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "Beneficities",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataConcessaoBeneficio",
                value: new DateTime(2022, 5, 21, 20, 41, 30, 762, DateTimeKind.Local).AddTicks(6733));

            migrationBuilder.UpdateData(
                table: "Beneficities",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataConcessaoBeneficio",
                value: new DateTime(2022, 5, 22, 20, 41, 30, 762, DateTimeKind.Local).AddTicks(6736));

            migrationBuilder.UpdateData(
                table: "Beneficities",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataConcessaoBeneficio",
                value: new DateTime(2022, 5, 16, 20, 41, 30, 762, DateTimeKind.Local).AddTicks(6739));

            migrationBuilder.UpdateData(
                table: "Beneficities",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataConcessaoBeneficio",
                value: new DateTime(2022, 5, 21, 20, 41, 30, 762, DateTimeKind.Local).AddTicks(6743));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "usuario1@hotmail.com", "Usuário 1", "12345", "admin" },
                    { 2, "usuario2@hotmail.com", "Usuário 2", "12345", "supervisor" },
                    { 3, "usuario3@hotmail.com", "Usuário 3", "12345", "operador" },
                    { 4, "usuario4@hotmail.com", "Usuário 4", "12345", "operador" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Beneficities",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataConcessaoBeneficio",
                value: new DateTime(2022, 5, 3, 7, 47, 50, 158, DateTimeKind.Local).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "Beneficities",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataConcessaoBeneficio",
                value: new DateTime(2022, 5, 4, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(453));

            migrationBuilder.UpdateData(
                table: "Beneficities",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataConcessaoBeneficio",
                value: new DateTime(2022, 5, 2, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(482));

            migrationBuilder.UpdateData(
                table: "Beneficities",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataConcessaoBeneficio",
                value: new DateTime(2022, 5, 1, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(490));

            migrationBuilder.UpdateData(
                table: "Beneficities",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataConcessaoBeneficio",
                value: new DateTime(2022, 4, 29, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(493));

            migrationBuilder.UpdateData(
                table: "Beneficities",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataConcessaoBeneficio",
                value: new DateTime(2022, 5, 3, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(504));

            migrationBuilder.UpdateData(
                table: "Beneficities",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataConcessaoBeneficio",
                value: new DateTime(2022, 5, 3, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(506));

            migrationBuilder.UpdateData(
                table: "Beneficities",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataConcessaoBeneficio",
                value: new DateTime(2022, 5, 4, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "Beneficities",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataConcessaoBeneficio",
                value: new DateTime(2022, 4, 28, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(511));

            migrationBuilder.UpdateData(
                table: "Beneficities",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataConcessaoBeneficio",
                value: new DateTime(2022, 5, 3, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(515));
        }
    }
}
