using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioBenner.Migrations
{
    /// <inheritdoc />
    public partial class Migr4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duracao",
                table: "ControleEstacionamento",
                newName: "Minutos");

            migrationBuilder.AddColumn<double>(
                name: "HorasTotais",
                table: "ControleEstacionamento",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorasTotais",
                table: "ControleEstacionamento");

            migrationBuilder.RenameColumn(
                name: "Minutos",
                table: "ControleEstacionamento",
                newName: "Duracao");
        }
    }
}
