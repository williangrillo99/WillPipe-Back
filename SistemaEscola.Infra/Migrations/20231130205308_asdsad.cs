using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEscola.Infra.Migrations
{
    /// <inheritdoc />
    public partial class asdsad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "Cartaos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Index",
                table: "Cartaos");
        }
    }
}
