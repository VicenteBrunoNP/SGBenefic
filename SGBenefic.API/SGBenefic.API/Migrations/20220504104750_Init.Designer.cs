﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGBenefic.API.Data;

namespace SGBenefic.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220504104750_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SGBenefic.API.Models.Beneficit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Beneficio")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("BeneficioUtilizado")
                        .HasColumnType("int");

                    b.Property<string>("CodigoBeneficio")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Comentario")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CpfCnpj")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DataConcessaoBeneficio")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataUtilizacaoBeneficio")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataValidadeBeneficio")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nivel")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OrgCod")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Beneficities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Beneficio = "Benefício 1",
                            BeneficioUtilizado = 0,
                            CodigoBeneficio = "1",
                            CpfCnpj = "71.096.708/0001-36",
                            DataConcessaoBeneficio = new DateTime(2022, 5, 3, 7, 47, 50, 158, DateTimeKind.Local).AddTicks(4476),
                            Nivel = "1",
                            OrgCod = "1",
                            RazaoSocial = "Martin e Emily Comercio de Bebidas ME"
                        },
                        new
                        {
                            Id = 2,
                            Beneficio = "Benefício 1",
                            BeneficioUtilizado = 0,
                            CodigoBeneficio = "1",
                            CpfCnpj = "30.531.043/0001-64",
                            DataConcessaoBeneficio = new DateTime(2022, 5, 4, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(453),
                            Nivel = "2",
                            OrgCod = "1",
                            RazaoSocial = "Andrea e Levi Lavanderia ME"
                        },
                        new
                        {
                            Id = 3,
                            Beneficio = "Benefício 2",
                            BeneficioUtilizado = 1,
                            CodigoBeneficio = "2",
                            CpfCnpj = "69.790.315/0001-86",
                            DataConcessaoBeneficio = new DateTime(2022, 5, 2, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(482),
                            Nivel = "2",
                            OrgCod = "1",
                            RazaoSocial = "Kauê e Rodrigo Telas Ltda"
                        },
                        new
                        {
                            Id = 4,
                            Beneficio = "Benefício 2",
                            BeneficioUtilizado = 1,
                            CodigoBeneficio = "2",
                            CpfCnpj = "65.529.487/0001-40",
                            DataConcessaoBeneficio = new DateTime(2022, 5, 1, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(490),
                            Nivel = "2",
                            OrgCod = "1",
                            RazaoSocial = "Gustavo e Manoel Ferragens Ltda"
                        },
                        new
                        {
                            Id = 5,
                            Beneficio = "Benefício 3",
                            BeneficioUtilizado = 0,
                            CodigoBeneficio = "3",
                            CpfCnpj = "53.512.884/0001-20",
                            DataConcessaoBeneficio = new DateTime(2022, 4, 29, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(493),
                            Nivel = "1",
                            OrgCod = "1",
                            RazaoSocial = "Emanuelly e Kauê Locações de Automóveis Ltda"
                        },
                        new
                        {
                            Id = 6,
                            Beneficio = "Benefício 3",
                            BeneficioUtilizado = 0,
                            CodigoBeneficio = "3",
                            CpfCnpj = "92.591.075/0001-02",
                            DataConcessaoBeneficio = new DateTime(2022, 5, 3, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(504),
                            Nivel = "2",
                            OrgCod = "1",
                            RazaoSocial = "Juliana e Agatha Eletrônica ME"
                        },
                        new
                        {
                            Id = 7,
                            Beneficio = "Benefício 4",
                            BeneficioUtilizado = 0,
                            CodigoBeneficio = "4",
                            CpfCnpj = "94.135.435/0001-97",
                            DataConcessaoBeneficio = new DateTime(2022, 5, 3, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(506),
                            Nivel = "1",
                            OrgCod = "1",
                            RazaoSocial = "Eloá e Fábio Filmagens Ltda"
                        },
                        new
                        {
                            Id = 8,
                            Beneficio = "Benefício 1",
                            BeneficioUtilizado = 1,
                            CodigoBeneficio = "1",
                            CpfCnpj = "20.479.947/0001-34",
                            DataConcessaoBeneficio = new DateTime(2022, 5, 4, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(509),
                            Nivel = "1",
                            OrgCod = "1",
                            RazaoSocial = "Cecília e Calebe Advocacia ME"
                        },
                        new
                        {
                            Id = 9,
                            Beneficio = "Benefício 5",
                            BeneficioUtilizado = 0,
                            CodigoBeneficio = "5",
                            CpfCnpj = "46.015.455/0001-81",
                            DataConcessaoBeneficio = new DateTime(2022, 4, 28, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(511),
                            Nivel = "2",
                            OrgCod = "1",
                            RazaoSocial = "Marlene e Letícia Assessoria Jurídica Ltda"
                        },
                        new
                        {
                            Id = 10,
                            Beneficio = "Benefício 1",
                            BeneficioUtilizado = 0,
                            CodigoBeneficio = "1",
                            CpfCnpj = "95.985.809/0001-26",
                            DataConcessaoBeneficio = new DateTime(2022, 5, 3, 7, 47, 50, 160, DateTimeKind.Local).AddTicks(515),
                            Nivel = "2",
                            OrgCod = "1",
                            RazaoSocial = "Sara e Sara Pães e Doces Ltda"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}