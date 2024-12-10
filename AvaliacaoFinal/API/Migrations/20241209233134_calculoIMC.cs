using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class calculoIMC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Altura",
                table: "Aluno",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Aluno",
                type: "TEXT",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Peso",
                table: "Aluno",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "resultadoImc",
                table: "Aluno",
                type: "REAL",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Altura",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "resultadoImc",
                table: "Aluno");
        }
    }
}
