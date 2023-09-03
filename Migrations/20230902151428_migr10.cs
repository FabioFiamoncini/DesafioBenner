using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioBenner.Migrations
{
    /// <inheritdoc />
    public partial class migr10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControleEstacionamento_Precos_PrecosId",
                table: "ControleEstacionamento");

            migrationBuilder.AlterColumn<int>(
                name: "PrecosId",
                table: "ControleEstacionamento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ControleEstacionamento_Precos_PrecosId",
                table: "ControleEstacionamento",
                column: "PrecosId",
                principalTable: "Precos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControleEstacionamento_Precos_PrecosId",
                table: "ControleEstacionamento");

            migrationBuilder.AlterColumn<int>(
                name: "PrecosId",
                table: "ControleEstacionamento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ControleEstacionamento_Precos_PrecosId",
                table: "ControleEstacionamento",
                column: "PrecosId",
                principalTable: "Precos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
