﻿// <auto-generated />
using System;
using DesafioBenner.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesafioBenner.Migrations
{
    [DbContext(typeof(DesafioBennerContext))]
    [Migration("20230902150307_migr8")]
    partial class migr8
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DesafioBenner.Models.ControleEstacionamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("HorasTotais")
                        .HasColumnType("float");

                    b.Property<double?>("Minutos")
                        .HasColumnType("float");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrecosId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tempo_entrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Tempo_saida")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Valor_adicional")
                        .HasColumnType("float");

                    b.Property<double?>("Valor_final")
                        .HasColumnType("float");

                    b.Property<double?>("Valor_hora")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PrecosId");

                    b.ToTable("ControleEstacionamento");
                });

            modelBuilder.Entity("DesafioBenner.Models.Precos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data_final")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_inicial")
                        .HasColumnType("datetime2");

                    b.Property<double>("Valor_adicional")
                        .HasColumnType("float");

                    b.Property<double>("Valor_inicial")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Precos");
                });

            modelBuilder.Entity("DesafioBenner.Models.ControleEstacionamento", b =>
                {
                    b.HasOne("DesafioBenner.Models.Precos", null)
                        .WithMany("Controles")
                        .HasForeignKey("PrecosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DesafioBenner.Models.Precos", b =>
                {
                    b.Navigation("Controles");
                });
#pragma warning restore 612, 618
        }
    }
}