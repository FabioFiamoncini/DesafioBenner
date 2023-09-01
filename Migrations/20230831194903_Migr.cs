using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioBenner.Migrations
{
    /// <inheritdoc />
    public partial class Migr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControleEstacionamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tempo_entrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tempo_saida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duracao = table.Column<double>(type: "float", nullable: false),
                    Valor_hora = table.Column<double>(type: "float", nullable: false),
                    Valor_adicional = table.Column<double>(type: "float", nullable: false),
                    Valor_final = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControleEstacionamento", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControleEstacionamento");
        }
    }
}
