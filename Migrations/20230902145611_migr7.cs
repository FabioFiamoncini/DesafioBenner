using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioBenner.Migrations
{
    /// <inheritdoc />
    public partial class migr7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrecosId",
                table: "ControleEstacionamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ControleEstacionamento_PrecosId",
                table: "ControleEstacionamento",
                column: "PrecosId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControleEstacionamento_Precos_PrecosId",
                table: "ControleEstacionamento",
                column: "PrecosId",
                principalTable: "Precos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControleEstacionamento_Precos_PrecosId",
                table: "ControleEstacionamento");

            migrationBuilder.DropIndex(
                name: "IX_ControleEstacionamento_PrecosId",
                table: "ControleEstacionamento");

            migrationBuilder.DropColumn(
                name: "PrecosId",
                table: "ControleEstacionamento");
        }
    }
}
