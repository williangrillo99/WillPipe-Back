using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEscola.Infra.Migrations
{
    /// <inheritdoc />
    public partial class asdasddasdaasdasdldasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartaos_Colunas_ColunaId",
                table: "Cartaos");

            migrationBuilder.DropColumn(
                name: "IdColuna",
                table: "Cartaos");

            migrationBuilder.AlterColumn<int>(
                name: "ColunaId",
                table: "Cartaos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cartaos_Colunas_ColunaId",
                table: "Cartaos",
                column: "ColunaId",
                principalTable: "Colunas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartaos_Colunas_ColunaId",
                table: "Cartaos");

            migrationBuilder.AlterColumn<int>(
                name: "ColunaId",
                table: "Cartaos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdColuna",
                table: "Cartaos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cartaos_Colunas_ColunaId",
                table: "Cartaos",
                column: "ColunaId",
                principalTable: "Colunas",
                principalColumn: "Id");
        }
    }
}
