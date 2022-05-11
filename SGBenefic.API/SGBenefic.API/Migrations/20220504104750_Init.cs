using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGBenefic.API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beneficities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CpfCnpj = table.Column<string>(nullable: true),
                    RazaoSocial = table.Column<string>(nullable: true),
                    Nivel = table.Column<string>(nullable: true),
                    CodigoBeneficio = table.Column<string>(nullable: false),
                    Beneficio = table.Column<string>(nullable: false),
                    OrgCod = table.Column<string>(nullable: false),
                    DataConcessaoBeneficio = table.Column<DateTime>(nullable: false),
                    DataValidadeBeneficio = table.Column<DateTime>(nullable: true),
                    DataUtilizacaoBeneficio = table.Column<DateTime>(nullable: true),
                    BeneficioUtilizado = table.Column<int>(nullable: false),
                    Comentario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Beneficities",
                columns: new[] { "Id", "Beneficio", "BeneficioUtilizado", "CodigoBeneficio", "Comentario", "CpfCnpj", "DataConcessaoBeneficio", "DataUtilizacaoBeneficio", "DataValidadeBeneficio", "Nivel", "OrgCod", "RazaoSocial" },
                values: new object[,]
                {
                    { 1, "Benefício 1", 0, "1", null, "71.096.708/0001-36", new DateTime(2022, 5, 3, 7, 47, 50, 158, DateTimeKind.Local).AddTicks(4476), null, null, "1", "1", "Martin e Emily Comercio de Bebidas ME" },
                    { 2, "Benefício 1", 0, "1", null, "30.531.043/0001-64", new DateTime(2022, 5, 4, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(453), null, null, "2", "1", "Andrea e Levi Lavanderia ME" },
                    { 3, "Benefício 2", 1, "2", null, "69.790.315/0001-86", new DateTime(2022, 5, 2, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(482), null, null, "2", "1", "Kauê e Rodrigo Telas Ltda" },
                    { 4, "Benefício 2", 1, "2", null, "65.529.487/0001-40", new DateTime(2022, 5, 1, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(490), null, null, "2", "1", "Gustavo e Manoel Ferragens Ltda" },
                    { 5, "Benefício 3", 0, "3", null, "53.512.884/0001-20", new DateTime(2022, 4, 29, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(493), null, null, "1", "1", "Emanuelly e Kauê Locações de Automóveis Ltda" },
                    { 6, "Benefício 3", 0, "3", null, "92.591.075/0001-02", new DateTime(2022, 5, 3, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(504), null, null, "2", "1", "Juliana e Agatha Eletrônica ME" },
                    { 7, "Benefício 4", 0, "4", null, "94.135.435/0001-97", new DateTime(2022, 5, 3, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(506), null, null, "1", "1", "Eloá e Fábio Filmagens Ltda" },
                    { 8, "Benefício 1", 1, "1", null, "20.479.947/0001-34", new DateTime(2022, 5, 4, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(509), null, null, "1", "1", "Cecília e Calebe Advocacia ME" },
                    { 9, "Benefício 5", 0, "5", null, "46.015.455/0001-81", new DateTime(2022, 4, 28, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(511), null, null, "2", "1", "Marlene e Letícia Assessoria Jurídica Ltda" },
                    { 10, "Benefício 1", 0, "1", null, "95.985.809/0001-26", new DateTime(2022, 5, 3, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(515), null, null, "2", "1", "Sara e Sara Pães e Doces Ltda" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beneficities");
        }
    }
}
