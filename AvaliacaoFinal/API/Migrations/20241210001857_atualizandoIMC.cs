using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class atualizandoIMC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "IMC",
                columns: table => new
                {
                    ImcID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Altura = table.Column<double>(type: "REAL", nullable: false),
                    Peso = table.Column<double>(type: "REAL", nullable: false),
                    resultadoImc = table.Column<double>(type: "REAL", nullable: false),
                    classificacao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMC", x => x.ImcID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IMC");

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
    }
}
